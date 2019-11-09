using DictionaryV2.Core.DataAccess.EntityFramework;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryV2.DataAccess.Concreate.EntityFramework
{
    public class EfRepeatDal : EfRepositoryBase<Repeat>, IRepeatDal
    {
        private DictionaryContext _context;
        public EfRepeatDal(DictionaryContext context) :
            base(context) {

            _context = context;
        }

        public List<Repeat> GetRepeatsWithDictionaryNotDone() {
            var repeatedList = _context.Repeat.Where(x => x.DoneFlag == false).ToList();

            return repeatedList;
        }

        public void UpdateDoneFlagByDictionaryId(int dictionaryId) {
            var repeat = _context.Repeat.Where(x => x.DictionaryId == dictionaryId).ToList();
            if (repeat == null)
                throw new Exception("Not Found");

            repeat[0].DoneFlag = true;
            _context.Repeat.Update(repeat[0]);
            _context.SaveChanges();
        }
    }
}
