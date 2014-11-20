using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Core.Infrastructure
{
    public class Page
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Page()
        {
            PageIndex = 1;
            PageSize = 10;
        }

        public Page(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int Skip
        {
            get { return (PageIndex - 1) * PageSize; }
        }
    }

    public static class PagingExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, Page page)
        {
            return queryable.Skip(page.Skip).Take(page.PageSize);
        }
    }
}
