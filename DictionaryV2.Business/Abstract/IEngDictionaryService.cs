using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Business.Abstract {
    public interface IEngDictionaryService {

        void Add(EngDictionary entity);
        void Delete(EngDictionary entity);

        List<EngDictionary> GetAll();
    }
}
