using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Entity.Concreate {
    public class EngDictionary {

        public int Id { get; set; }

        public DateTime InsertDate { get; set; }

        public string EngStr { get; set; }

        public string TrStr { get; set; }
    }
}
