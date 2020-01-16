using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bookmarker.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BookmarkerUsers class
    public class BookmarkerUsers : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        public string Caption { get; set; }

        [PersonalData]
        public DateTime JoinedOn { get; set; }
    }
}
