using Bookmarker.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarker.Models
{
    public class CategoryModels
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public BookmarkerUsers Users { get; set; }

        public IList<BookmarksModels> Bookmarks { get; set; }
    }
}
