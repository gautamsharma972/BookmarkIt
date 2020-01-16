using Bookmarker.Helpers;
using Bookmarker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarker.Controllers
{
    public class BaseController : Controller
    {
        private readonly IBookmarkRepository _bookmarks;
        private readonly AppDbContext _db;
        private readonly ICurrentUser _cUser;
        public BaseController(IBookmarkRepository bookmarks, AppDbContext db, ICurrentUser cUser)
        {
            _bookmarks = bookmarks;
            _db = db;
            _cUser = cUser;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Bookmarks = GetCount("bookmarks");
            ViewBag.Categories = GetCount("categories");
            base.OnActionExecuting(context);
        }

        private int GetCount(string type)
        {
            if (type == "bookmarks")
            {
                var _bk = _db.Bookmarks.Include(a=>a.Users).Where(a=>a.Users.Id == _cUser.User.Id).Count();
                return _bk;
            }
            else
            {
                var _cat = _db.Categories.Include(a => a.Users).Where(a => a.Users.Id == _cUser.User.Id).Count();
                return _cat;
            }
        }
    }
}