using DictionaryV2.Core.DataAccess.EntityFramework;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.DataAccess.Concreate.EntityFramework {
    public class EfEngDictionaryDal : EfRepositoryBase<EngDictionary>, IEngDictionaryDal {
        public EfEngDictionaryDal(DictionaryContext context) : 
            base(context) {

        }
    }
}
