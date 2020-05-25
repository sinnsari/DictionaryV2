using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Entity.Concreate {
    public class PagingParam {
        private int maxPageSize = 100;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;
        public int PageSize {
            get {
                return pageSize;
            }
            set {
                pageSize = value > maxPageSize ? maxPageSize : value;
            }
        }

        public int StartDay { get; set; }
        public int EndDay { get; set; }
        public string OrderBy { get; set; }
    }
}
