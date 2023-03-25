using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeAnagramsASP
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }

        public bool HasPreviousPage { get { return PageIndex > 1; } }
        public bool HasNextPage { get { return PageIndex < TotalPages; }}
        public PaginatedList(IEnumerable<T> items, int pageIndex, int totalItems, int pageSize = 25)
        {
            TotalResults = totalItems;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(TotalResults / (double)pageSize);

            this.AddRange(items);
        }

        public static PaginatedList<T> Create(IEnumerable<T> original, int pageIndex, int pageSize = 25 )
        {
            IEnumerable<T> items = original;

            items = items.Skip((pageIndex-1) * pageSize)
                         .Take(pageSize);

            return new PaginatedList<T>(items, pageIndex, original.Count(), pageSize);
        }
        public static PaginatedList<T> Create(IEnumerable<T> original, int pageIndex,Func<T, bool> filter, int pageSize = 25)
        {
            IEnumerable<T> items = original.Where(filter);
            return PaginatedList<T>.Create(items, pageIndex, pageSize);
        }
    }

}
