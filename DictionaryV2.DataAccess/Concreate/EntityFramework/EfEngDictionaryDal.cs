using DictionaryV2.Core.DataAccess.EntityFramework;
using DictionaryV2.Core.Extensions;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryV2.DataAccess.Concreate.EntityFramework {
    public class EfEngDictionaryDal : EfRepositoryBase<EngDictionary>, IEngDictionaryDal {
        private DbContext _context;
        public EfEngDictionaryDal(DictionaryContext context) : 
            base(context) {

            _context = context;
        }

        public List<EngDictionary> GetAllByRandom() {

            var list = _context.Set<EngDictionary>().ToList();
            list.Shuffle();

            return list;
        }
    }
}
