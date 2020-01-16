﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookmarker.Helpers;
using Bookmarker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Bookmarker.Helpers.Enums;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Bookmarker.Controllers
{
    [Authorize]
    public class BookmarksController : BaseController
    {
        private readonly IBookmarkRepository _bookmarks;
        private readonly AppDbContext _db;
        private readonly ICurrentUser _cUser;
        public BookmarksController(IBookmarkRepository bookmarks, AppDbContext db, ICurrentUser cUser)
            : base(bookmarks, db, cUser)
        {
            _bookmarks = bookmarks;
            _db = db;
            _cUser = cUser;
        }
        // GET: Bookmarks
        public async Task<IActionResult> Index()
        {
            var model = await _bookmarks.Get();
            var _catCount = await _bookmarks.Categories();
            ViewBag.CategoryCount = _catCount.Count;
            return View(model);
        }

        // GET: Bookmarks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bookmarks/Create
        public async Task<ActionResult> Create(string Site ="", string Link="", string Type="")
        {
            var _cat = await _bookmarks.Categories(Type);
            List<SelectListItem> selCat = new List<SelectListItem>();
            foreach (var item in _cat)
            {
                selCat.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return View(new BookmarksModels { SiteName = Site, SiteLink = Link, AvailableBookmarkTypes = selCat });
        }

        [HttpPost]
        public JsonResult Preview(string url)
        {
            Scrap scrap = new Scrap();
            if (!string.IsNullOrWhiteSpace(url))
            {
                scrap = GetScrap(url);
            }
            return Json(scrap);
        }

        public async Task<ActionResult> New(string Site, string Link,string Type)
        {
            var _cat = await _bookmarks.Categories(Type);
            List<SelectListItem> selCat = new List<SelectListItem>();
            foreach(var item in _cat)
            {
                selCat.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return View(new BookmarksModels { SiteName = Site, SiteLink = Link, AvailableBookmarkTypes = selCat });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(BookmarksModels model)
        {
            if (!ModelState.IsValid) return View(model);
            bool result = await _bookmarks.Create(model);
            if (result)
            {
                return Json(new { msg = "Saved", error = false });
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred. Please try again later.");
                return View(model);
            }

        }

        // POST: Bookmarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookmarksModels model)
        {
            if (!ModelState.IsValid) return View(model);
            bool result = await _bookmarks.Create(model);
            if (result)
            {
                return Json(new { msg = "Saved", error = false }); 
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred. Please try again later.");
                return View(model);
            }

        }

        [HttpPost]
        public async Task<ActionResult> NewCategory(string category)
        {
            var result = await _bookmarks.AddCategory(category);
            if (result!=null)
            {
                return Json(new { category = result, erorr=false, msg = "" });
            }
            else
            {
                return Json(new { error = true, msg= "Some erorr occurred. Please try again later."});
            }
        }

        // GET: Bookmarks/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var vm = await _bookmarks.Get(id);
            
            var _cat = await _bookmarks.Categories("");
            List<SelectListItem> selCat = new List<SelectListItem>();
            foreach (var item in _cat)
            {
                if(vm.Category.Id == item.Id)
                {
                    selCat.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    selCat.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = false
                    });
                }
                
            }
            vm.AvailableBookmarkTypes = selCat;
            vm.SelectedCategory = Guid.Parse(selCat.Where(a => a.Selected).FirstOrDefault().Value.ToString());
            return PartialView(vm);
        }

        // POST: Bookmarks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BookmarksModels model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid) return View(model);
            bool result = await _bookmarks.Edit(id, model);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Some error occurred. Please try again later.");
            return View(model);

        }

        // GET: Bookmarks/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _bookmarks.Get(id);
            return PartialView(model);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, BookmarksModels model)
        {
            var success = await _bookmarks.Delete(Id, model);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Some error occurred. Please try again later.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAll()
        {
            var success = await _bookmarks.RemoveAll();
            if (success)
            {
                return Json(new { msg = "Successfully deleted.", error = false });
            }
            return Json(new { msg = "Some error occurred. Please try again later.", error = true });
        }

        public static Scrap GetScrap(string url)
        {
            Scrap scrap = new Scrap();

            string[] imgs = new string[100];
            List<string> lstUrl = new List<string>();
            List<string> TempImages = new List<string>();

            lstUrl = GetUrlList(url);

            string validUrl = GetValidUrl(lstUrl);

            if (!string.IsNullOrWhiteSpace(validUrl))
            {

                string s2 = GetHtmlPage(validUrl);

                scrap.url = validUrl;
                var metadata = MetaDescription(s2);
                scrap.description = (string.IsNullOrEmpty(metadata.desc) ? "" : metadata.desc);

                if (!string.IsNullOrEmpty(metadata.image))
                {
                    TempImages.Add(metadata.image);
                }
                else
                {
                    var images = GetRegImages(s2);
                    foreach (var item in images)
                    {
                        if (item.ToLower().Contains("logo"))
                        {
                            TempImages.Insert(0, item);

                            break;
                        }
                        else
                        {
                            TempImages.Add(item);
                        }
                    }
                }

                List<string> PerfactImageUrls;

                var task = Task.Run(() => formatImageUrl(TempImages, url));

                if (task.Wait(TimeSpan.FromSeconds(2)))
                {
                    PerfactImageUrls = task.Result.ToList<string>();
                    scrap.lstImages = PerfactImageUrls.Take(4).ToArray();
                }
                scrap.title = GetTitle(s2);
            }
            else
            {

            }

            return scrap;
        }

        public static List<string> CheckImage(List<string> images)
        {

            foreach (var item in images.ToList())
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(item);
                request.Method = "HEAD";

                request.UseDefaultCredentials = true;
                request.Accept = "*/*";
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                bool exists = false;
                try
                {
                    request.GetResponse();
                    exists = true;
                    var img = item;
                    images.Clear();
                    images.Add(img);
                    break;
                }
                catch
                {
                    exists = false;
                }

                if (!exists)
                {
                    images.Remove(item);
                }

            }
            return images;
        }

        public static List<string> GetUrlList(string url)
        {
            List<string> lstUrl = new List<string>();


            if (!url.Contains("http"))
            {
                if (!url.Contains("www"))
                {
                    lstUrl.Add("http://" + url);
                    lstUrl.Add("https://" + url);
                    lstUrl.Add("http://www." + url);
                    lstUrl.Add("https://www." + url);
                }
                else
                {
                    lstUrl.Add("http://" + url);
                    lstUrl.Add("https://" + url);
                }
            }
            else
            {
                if (!url.Contains("www"))
                {
                    if (url.Contains("http://"))
                    {
                        lstUrl.Add(url);
                        lstUrl.Add(url.Replace("http://", "http://www."));
                    }

                    else if (url.Contains("http://"))
                    {
                        lstUrl.Add(url);
                        lstUrl.Add(url.Replace("https://", "https://www."));
                    }
                    else
                    {
                        lstUrl.Add(url);
                    }
                }
                else
                {
                    lstUrl.Add(url);
                }

            }



            return lstUrl;
        }

        public static string GetValidUrl(List<string> url)
        {
            string imgUrl = string.Empty;
            HttpWebResponse response = null;

            foreach (var item in url)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    HttpWebRequest request = HttpWebRequest.Create(item) as HttpWebRequest;
                    try
                    {
                        response = request.GetResponse() as HttpWebResponse;
                        if (response.StatusCode.ToString().ToLower() == "ok")
                        {
                            imgUrl = item;

                            break;
                        }
                    }
                    catch (WebException e)
                    {
                        throw e;
                    }

                }
            }


            return imgUrl;
        }

        public static string GetHtmlPage(string strURL)
        {
            string strResult;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(strURL);
            objRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            WebResponse objResponse = objRequest.GetResponse();
            using (var sr = new StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();
                sr.Close();
            }
            return strResult;
        }

        public static MetaDescription MetaDescription(string s)
        {
            MetaDescription scrap = new MetaDescription();

            scrap.title = GetTitle(s);

            var metadata = GetWebPageMetaData(s);

            if (metadata != null)
            {

                foreach (Match item in metadata)
                {
                    for (int i = 0; i <= item.Groups.Count; i++)
                    {


                        if (item.Groups[i].Value.ToString().ToLower().Contains("description"))
                        {
                            scrap.desc = item.Groups[i + 1].Value;
                            break;

                        }

                        if (item.Groups[i].Value.ToString().ToLower().Contains("og:title"))
                        {
                            scrap.title = item.Groups[i + 1].Value;
                            break;
                        }

                        if (item.Groups[i].Value.ToString().ToLower().Contains("og:image"))
                        {
                            if (string.IsNullOrEmpty(scrap.image))
                            {
                                scrap.image = item.Groups[i + 1].Value;
                            }

                            break;
                        }
                        else if (item.Groups[i].Value.ToString().ToLower().Contains("image") && item.Groups[i].Value.ToString().ToLower().Contains("itemprop"))
                        {
                            scrap.image = item.Groups[i + 1].Value;
                            if (scrap.image.Length < 5)
                            {
                                scrap.image = null;
                            }
                            break;
                        }

                    }
                }
            }

            if (!string.IsNullOrEmpty(scrap.desc))
            {
                scrap.desc = System.Uri.UnescapeDataString(scrap.desc);
            }

            return scrap;
        }

        public static string GetTitle(string s)
        {
            Match m = Regex.Match(s, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
            {
                return string.Empty;
            }
        }

        public static MatchCollection GetWebPageMetaData(string s)
        {

            Regex m3 = new Regex("<meta[\\s]+[^>]*?content[\\s]?=[\\s\"\']+(.*?)[\"\']+.*?>");
            MatchCollection mc = m3.Matches(s);
            return mc;
        }

        public static List<string> GetRegImages(string str)
        {
            List<string> newimg = new List<string>();
            const string pattern = @"<img\b[^\<\>]+?\bsrc\s*=\s*[""'](?<L>.+?)[""'][^\<\>]*?\>";

            foreach (Match match in Regex.Matches(str, pattern, RegexOptions.IgnoreCase))
            {
                var imageLink = match.Groups["L"].Value;


                newimg.Add(imageLink);
            }

            return newimg;
        }

        public static List<string> formatImageUrl(List<string> TempImages, string url)
        {
            List<string> PerfactImageUrls = new List<string>();
            List<string> TempImageUrls = new List<string>();

            foreach (var item in TempImages)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (!item.Contains("http"))
                    {
                        TempImageUrls = GetImageUrlList(item, url);
                    }
                    else
                    {
                        TempImageUrls.Add(item);
                    }
                    TempImageUrls = CheckImage(TempImageUrls);

                    if (TempImageUrls.Count() > 0)
                    {
                        PerfactImageUrls.Add(TempImageUrls.FirstOrDefault().ToString());
                        TempImageUrls.Clear();
                    }

                    if (PerfactImageUrls.Count() == 4)
                    {
                        break;
                    }
                }
            }
            if (PerfactImageUrls.Count() == 0)
            {
                PerfactImageUrls.Add(string.Empty);
            }

            return PerfactImageUrls;
        }

        public static List<string> GetImageUrlList(string image, string url)
        {
            List<string> lstUrl = new List<string>();
            List<string> imageList = new List<string>();

            lstUrl = GetUrlList(url);

            foreach (var item in lstUrl)
            {
                if (!image.Contains("http"))
                {


                    if (image.StartsWith("//"))
                    {
                        if (image.Replace("//", "").ToString().ToLower().StartsWith("www"))
                        {
                            imageList.Add(image.Replace("//", "http://"));
                            imageList.Add(image.Replace("//", "https://"));
                        }
                        else
                        {
                            imageList.Add(image.Replace("//", "http://"));
                            imageList.Add(image.Replace("//", "https://"));
                            imageList.Add(image.Replace("//", item));
                        }
                    }
                    else if (image.StartsWith("/"))
                    {
                        imageList.Add(item + image);
                    }
                    else
                    {
                        imageList.Add(item + "/" + image);
                    }


                }
                else
                {
                    imageList.Add(item + "/" + image);
                }
            }
            return imageList;
        }

    }
}