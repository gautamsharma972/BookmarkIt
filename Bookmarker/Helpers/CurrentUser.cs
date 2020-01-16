
using Bookmarker.Areas.Identity.Data;
using Bookmarker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bookmarker.Helpers
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppDbContext _context;

        private BookmarkerUsers _user;

        public CurrentUser(IHttpContextAccessor httpContext, AppDbContext context)
        {
            _httpContext = httpContext;
            _context = context;
            
        }

        public BookmarkerUsers User
        {
            get {
                var currentUser = _user ?? (_user = _context.Users.SingleOrDefault(a => a.UserName == _httpContext.HttpContext.User.Identity.Name));
                if (currentUser == null)
                    currentUser = new BookmarkerUsers() { UserName = "Need to Login" };
                return currentUser;
            }
        }
        private void GetUser()
        {
            //ClaimsPrincipal currentUser = this.User;
            //var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //ApplicationUser user = await _userManager.FindByNameAsync(currentUserName);
        }

    }
}
