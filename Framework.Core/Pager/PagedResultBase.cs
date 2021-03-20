using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Pager
{
    public class PagedResultBase
    {
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public StaticPagedList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new StaticPagedList<T>(new List<T>(), 1, 10, 10);
        }
    }
}
