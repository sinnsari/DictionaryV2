using DictionaryV2.Core.DataAccess;
using DictionaryV2.Entity.Concreate;
using DictionaryV2.Entity.Concreate.ApiPaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.DataAccess.Abstract {
    public interface IEngDictionaryDal : IEntityRepository<EngDictionary> {

        List<EngDictionary> GetAllByRandom();

        List<EngDictionary> GetAllByRandomAndDate(DateTime date);

        PagedList<EngDictionary> GetByPaging(PagingParam param);
    }
}
