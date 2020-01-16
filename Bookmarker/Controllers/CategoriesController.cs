using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookmarker.Helpers;
using Bookmarker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarker.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        private readonly IBookmarkRepository _bookmarks;
        private readonly AppDbContext _db;
        private readonly ICurrentUser _cUser;
        public CategoriesController(IBookmarkRepository bookmark, AppDbContext db, ICurrentUser cUser)
            : base(bookmark, db, cUser)
        {
            _bookmarks = bookmark;
            _db = db;
            _cUser = cUser;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var model = await _bookmarks.Categories();
            var bk = await _bookmarks.Get();
            ViewBag.BookmarkCount = bk.Count;
            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("/Bookmarks/{name}/")]
        public async Task<IActionResult> Bookmarks(string name)
        {
            var vm = await _bookmarks.GetCategoriesByName(name);
            ViewBag.CategoryName = name;
            return View(vm);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _bookmarks.GetCategory(id);
            return PartialView(model);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoryModels model)
        {
            try
            {
                var result = await _bookmarks.EditCategory(id, model);
                if (result)
                {
                    return Json(new { error = false, msg = "Saved Successfully." });
                }
                else
                {
                    return Json(new { error = true, msg = "Some error occurred. Please try again later." });
                }
            }
            catch
            {
                return PartialView(model);
            }
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var vm = await _bookmarks.GetCategory(id);
            return PartialView(vm);
        }

        //// POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, CategoryModels model)
        {
            try
            {
                var result = await _bookmarks.DeleteCategory(Id);
                if (result)
                {
                    return Json(new { error = false, msg = $"{model.Name} was deleted successfully! " });
                }
                else
                {
                    return Json(new { error = true, msg = "Some error occurred. Please try again later." });
                }
            }
            catch
            {
                return Json(new { error = true, msg = "Some error occurred. Please try again later." });
            }
        }
    }
}