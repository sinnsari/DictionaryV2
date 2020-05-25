using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using DictionaryV2.Entity.Concreate.ApiPaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Business.Abstract {
    public interface IEngDictionaryService {

        void Add(EngDictionary entity);
        void Delete(EngDictionary entity);
        void Update(EngDictionary entity);

        List<EngDictionary> GetAll();

        List<EngDictionary> GetAllByRandom();

        List<EngDictionary> GetAllByRandomAndDate(DateTime date);

        List<EngDictionary> GetByFilter(Func<EngDictionary, bool> filter);

        PagedList<EngDictionary> GetByPaging(PagingParam param);
    }
}
