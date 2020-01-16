using Bookmarker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarker.Helpers
{
    public interface IBookmarkRepository
    {
        public Task<bool> Create(BookmarksModels model);
        public Task<bool> Edit(Guid id, BookmarksModels model);
        public Task<List<BookmarksModels>> Get();
        public Task<BookmarksModels> Get(Guid id);
        public Task<bool> Delete(Guid id, BookmarksModels model);
        public Task<bool> Delete(Guid id);
        public Task<IList<CategoryModels>> Categories();
        public Task<IList<CategoryModels>> Categories(string Type);
        public Task<CategoryModels> AddCategory(string category);
        public Task<bool> EditCategory(Guid id, CategoryModels model);
        public Task<bool> DeleteCategory(Guid id);
        public Task<CategoryModels> GetCategory(Guid id);
        public Task<IList<BookmarksModels>> GetCategoriesByName(string name);
        public Task<bool> RemoveAll();
    }
}
