using Bookmarker.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarker.Helpers
{
    public interface ICurrentUser
    {
        BookmarkerUsers User { get; }
    }
}
