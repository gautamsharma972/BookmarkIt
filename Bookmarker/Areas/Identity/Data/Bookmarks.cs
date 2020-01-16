using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Bookmarker.Helpers.Enums;

namespace Bookmarker.Areas.Identity.Data
{
    public class Bookmarks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string SiteName { get; set; }

        public string SiteLink { get; set; }

        public DateTime DateAdded { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public Category Category{ get; set; }

        public BookmarkerUsers Users { get; set; }

        public string BookmarkName { get; set; }
    }
}
