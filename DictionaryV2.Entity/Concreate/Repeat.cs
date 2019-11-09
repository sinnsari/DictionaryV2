using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Entity.Concreate
{
    public class Repeat
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public int DictionaryId { get; set; }
        public bool DoneFlag { get; set; }
    }
}
