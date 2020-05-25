using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Entity.Concreate.ApiPaging {
    public class PagingHeader {
        public int TotalPage { get; set; }
        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
