using DictionaryV2.Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Business.Abstract
{
    public interface IRepeatService
    {
        void Add(Repeat entity);
        void Delete(Repeat entity);
        void Update(Repeat entity);
        List<Repeat> GetAll();
        List<Repeat> GetRepeatsWithDictionaryNotDone();

        void UpdateDoneFlagByDictionaryId(int dictionaryId);
    }
}
