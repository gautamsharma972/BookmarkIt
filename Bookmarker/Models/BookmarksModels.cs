using Bookmarker.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Bookmarker.Helpers.Enums;

namespace Bookmarker.Models
{
    public class BookmarksModels
    {
        [UIHint("Hidden")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="You must enter the Site Name")]
        [Display(Name ="Site Name")]
        public string SiteName { get; set; }

        [Required(ErrorMessage = "You must enter the Website Link")]
        [Display(Name = "Website Link")]
        public string SiteLink { get; set; }

        public DateTime DateAdded { get; set; }

        public List<SelectListItem> AvailableBookmarkTypes { get; set; }
        public Category Category { get; set; }

        public Guid SelectedCategory { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
        public BookmarkerUsers Users { get; set; }

        [Required(ErrorMessage = "Please enter a unique Bookmark name, so you could remember them")]
        [Display(Name = "Bookmark Name")]
        public string BookmarkName { get; set; }
    }
}
