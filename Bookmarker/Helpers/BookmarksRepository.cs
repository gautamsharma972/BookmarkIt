using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookmarker.Areas.Identity.Data;
using Bookmarker.Controllers;
using Bookmarker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookmarker.Helpers
{
    public class BookmarksRepository : IBookmarkRepository
    {
        private readonly AppDbContext _db;
        private readonly ILogger<BookmarksController> _logger;
        private readonly UserManager<BookmarkerUsers> _userManager;
        private readonly ICurrentUser _currentUser;
        public BookmarksRepository(AppDbContext db,
            ILogger<BookmarksController> logger,
            UserManager<BookmarkerUsers> userManager, 
            ICurrentUser currentUser)
        {
            _db = db;
            _logger = logger;
            _currentUser = currentUser;
            _userManager = userManager;
        }
        public async Task<bool> Create(BookmarksModels model)
        {
            try
            {
                var _cat = _db.Categories.Where(a => a.Id == model.SelectedCategory).SingleOrDefault();
                var vm = new Bookmarks
                {
                    BookmarkName = model.BookmarkName,
                    Category = _cat,
                    DateAdded = DateTime.Now,
                    Id = Guid.NewGuid(),
                    SiteLink = model.SiteLink,
                    SiteName = model.SiteName,
                    Users = _currentUser.User,
                    Description = model.Description,
                    Image = model.Image
                };
                _db.Bookmarks.Add(vm);
                await _db.SaveChangesAsync();
                _logger.LogInformation($"New Bookmark added by {_currentUser.User.UserName}");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id, BookmarksModels model)
        {
            try
            {
                var vm = await _db.Bookmarks.Where(a => a.Id == id && a.Users.Id == _currentUser.User.Id).FirstOrDefaultAsync();

                _db.Bookmarks.Remove(vm);
                await _db.SaveChangesAsync();
                _logger.LogInformation($"{vm.Id} - Bookmark was deleted by {_currentUser.User.UserName}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
          
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var vm = await _db.Bookmarks.Where(a => a.Id == id && a.Users.Id == _currentUser.User.Id).FirstOrDefaultAsync();

                _db.Bookmarks.Remove(vm);
                await _db.SaveChangesAsync();
                _logger.LogInformation($"{vm.Id} - Bookmark was deleted by {_currentUser.User.UserName}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> Edit(Guid id, BookmarksModels model)
        {
            try
            {
                var vm = await _db.Bookmarks.Where(a => a.Id == id && a.Users.Id == _currentUser.User.Id).FirstOrDefaultAsync();
                if (vm == null)
                {
                    return false;
                }
                var _cat = await _db.Categories.Where(a => a.Id == model.SelectedCategory).SingleOrDefaultAsync();
                vm.BookmarkName = model.BookmarkName;
                vm.Category = _cat;
                vm.DateAdded = DateTime.Now;             
                vm.SiteLink = model.SiteLink;
                vm.SiteName = model.SiteName;
                vm.Description = model.Description;
                vm.Image = model.Image;
                await _db.SaveChangesAsync();
                _logger.LogInformation($"{vm.Id} - Bookmark modified by {_currentUser.User.UserName}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public async Task<BookmarksModels> Get(Guid id)
        {
            var vm = await _db.Bookmarks.Include(a=>a.Category).
                Where(a => a.Id == id && a.Users.Id == _currentUser.User.Id).FirstOrDefaultAsync();
            var model = new BookmarksModels
            {
                Id = vm.Id,
                BookmarkName = vm.BookmarkName,
                Category = vm.Category,
                DateAdded = vm.DateAdded,
                SiteLink = vm.SiteLink,
                SiteName = vm.SiteName,
                Users = vm.Users,
                Description = vm.Description,
                Image = vm.Image
            };
            return model;
        }

        public async Task<List<BookmarksModels>> Get()
        {
            List<Bookmarks> vm = await _db.Bookmarks.Include(a=>a.Category).Include(a => a.Users).
                Where(a => a.Users.Id == _currentUser.User.Id).ToListAsync();
            var model = new List<BookmarksModels>();
            foreach (var item in vm)
            {
                model.Add(new BookmarksModels
                {
                    BookmarkName = item.BookmarkName,
                    Category = item.Category,
                    DateAdded = item.DateAdded,
                    Id = item.Id,
                    SiteLink = item.SiteLink,
                    SiteName = item.SiteName,
                    Users = item.Users,
                    Description = item.Description,
                    Image = item.Image
                });
            }
            return model;
        }

        public async Task<IList<CategoryModels>> Categories(string Type)
        {
            var vm = await _db.Categories.Include(a=>a.Users).
                Where(a=>a.Users.Id == _currentUser.User.Id).ToListAsync();
            if (!string.IsNullOrEmpty(Type))
            {
                vm = vm.Where(a => a.Name.ToLower().Equals(Type.ToLower().Trim())).ToList();
            }
            var model = new List<CategoryModels>();
            foreach(var item in vm)
            {
                model.Add(new CategoryModels
                {
                    DateCreated = item.DateCreated,
                    Id = item.Id,
                    Name = item.Name,
                    Users = item.Users
                });
            }
            return model;
        }

        public async Task<IList<BookmarksModels>> GetCategoriesByName(string name)
        {
            var model = new List<BookmarksModels>();
            var vm = await _db.Bookmarks.Include(a=>a.Users).Include(a => a.Category).
                Where(a => a.Category.Name.ToLower() == name.ToLower().Trim() && a.Users.Id == _currentUser.User.Id).ToListAsync();
            foreach (var item in vm)
            {
                model.Add(new BookmarksModels
                {
                    BookmarkName = item.BookmarkName,
                    Category = item.Category,
                    DateAdded = item.DateAdded,
                    Description = item.Description,
                    Id = item.Id,
                    Image = item.Image,
                    SiteLink = item.SiteLink,
                    SiteName = item.SiteName,
                    Users = item.Users
                });
            }
            return model;
        }

        public async Task<IList<CategoryModels>> Categories()
        {
            var vm = await _db.Categories.Include(a => a.Users).
                Where(a => a.Users.Id == _currentUser.User.Id).ToListAsync();
            
            var model = new List<CategoryModels>();
            foreach (var item in vm)
            {
                model.Add(new CategoryModels
                {
                    DateCreated = item.DateCreated,
                    Id = item.Id,
                    Name = item.Name,
                    Users = item.Users,
                    Bookmarks = GetBookmarksByCategory(item)
                });
            }
            return model;
        }

        private List<BookmarksModels> GetBookmarksByCategory(Category category)
        {
            var model = new List<BookmarksModels>();
            var vm = _db.Bookmarks.Include(a => a.Category).Where(a => a.Category.Id == category.Id).ToList();
            foreach(var item in vm)
            {
                model.Add(new BookmarksModels
                {
                    BookmarkName = item.BookmarkName,
                    Category = item.Category,
                    DateAdded = item.DateAdded,
                    Description = item.Description,
                    Id = item.Id,
                    Image = item.Image,
                    SiteLink = item.SiteLink,
                    SiteName = item.SiteName,
                    Users = item.Users
                });
            }
            return model;
        }

        public async Task<CategoryModels> AddCategory(string category)
        {
            try
            {
                var vm = _db.Categories.Where(a => a.Name.ToLower().Equals(category.ToLower().Trim())).SingleOrDefault();
                if(vm == null)
                {
                    vm = new Category
                    {
                        DateCreated = DateTime.Now,
                        Id = Guid.NewGuid(),
                        Name = category.Trim(),
                        Users = _currentUser.User
                    };
                    _db.Categories.Add(vm);
                    await _db.SaveChangesAsync();
                }

                var model = new CategoryModels
                {
                    DateCreated = vm.DateCreated,
                    Id = vm.Id,
                    Name = vm.Name,
                    Users = vm.Users
                };
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CategoryModels> GetCategory(Guid id)
        {
            var vm = await _db.Categories.Include(a=>a.Users).Where(a => a.Id == id && a.Users.Id == _currentUser.User.Id).SingleOrDefaultAsync();
            if(vm == null)
            {
                return null;
            }
            var model = new CategoryModels
            {
                DateCreated = vm.DateCreated,
                Id = vm.Id,
                Name = vm.Name,
                Users = vm.Users
            };
            return model;
        }

        public async Task<bool> EditCategory(Guid id, CategoryModels model)
        {
            try
            {
                var vm = await _db.Categories.Include(a => a.Users).Where(a => a.Id == id && a.Users.Id == _currentUser.User.Id).SingleOrDefaultAsync();
                if (vm == null)
                {
                    return false;
                }
                vm.Name = model.Name;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            try
            {
                var vm = await _db.Categories.Include(a => a.Users).Where(a => a.Id == id && a.Users.Id == _currentUser.User.Id).SingleOrDefaultAsync();
                if (vm == null)
                {
                    return false;
                }
                var bookmarks = _db.Bookmarks.Where(a => a.Category.Id == vm.Id && a.Users.Id == _currentUser.User.Id).ToList();
                if (bookmarks.Count > 0)
                {
                    _db.Bookmarks.RemoveRange(bookmarks);
                }
                _db.Categories.Remove(vm);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveAll()
        {
            try
            {
                var vm = await _db.Bookmarks.Include(a => a.Users).Where(a => a.Users.Id == _currentUser.User.Id).ToListAsync();
                if (vm.Count > 0)
                {
                    _db.Bookmarks.RemoveRange(vm);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
