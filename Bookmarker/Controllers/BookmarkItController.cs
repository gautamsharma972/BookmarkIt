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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarkItController : ControllerBase
    {
        private readonly IBookmarkRepository _bookmarks;
        public BookmarkItController(IBookmarkRepository bookmark)
        {
            _bookmarks = bookmark;
        }
        // GET: api/BookmarkIt
        [HttpGet]
        public async Task<IEnumerable<BookmarksModels>> Get()
        {
            var model = await _bookmarks.Get();
            return model;
        }

        // GET: api/BookmarkIt/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<BookmarksModels> Get(Guid id)
        {
            var model = await _bookmarks.Get(id);
            return model;
        }

        // POST: api/BookmarkIt
        [HttpPost]
        public async Task<string> Post([FromBody] BookmarksModels model)
        {
            bool success = await _bookmarks.Create(model);
            if (success)
            {
                return "Bookmark Created";
            }
            return "Some error occurred while creating your bookmark. Please try again later.";
        }

        // PUT: api/BookmarkIt/5
        [HttpPut("{id}")]
        public async Task<string> Put(Guid id, [FromBody] BookmarksModels model)
        {
            var _obj = await _bookmarks.Get(id);
            if (_obj == null)
                return "Bookmark not found!";

            bool success = await _bookmarks.Edit(id, model);
            if (success)
            {
                return "Bookmark was modified";
            }
            return "Some error occurred. Please try again.";

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(Guid id)
        {
            var _obj = await _bookmarks.Get(id);
            if (_obj == null)
                return "Bookmark not found!";

            bool success = await _bookmarks.Delete(id);
            if (success)
            {
                return "Bookmark was deleted";
            }
            return "Some error occurred. Please try again.";
        }
    }
}
