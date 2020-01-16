using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarker.Models
{
    public class Scrap
    {
        public string title { get; set; }

        public string description { get; set; }

        public string url { get; set; }

        public string[] lstImages { get; set; }

    }

    public class MetaDescription
    {
        public string title { get; set; }

        public string image { get; set; }

        public string desc { get; set; }

    }
}
