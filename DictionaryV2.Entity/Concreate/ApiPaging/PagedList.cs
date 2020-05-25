using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryV2.Entity.Concreate.ApiPaging {
    public class PagedList<T> : List<T> {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalItems { get; set; }
        public int TotalPage { get; set; }

        public PagedList(IQueryable<T> query,int pageSize, int pageNumber) {

            TotalItems = query.Count();
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling(TotalItems / (double)PageSize);
            this.AddRange(query.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList());
        }

    }
}
