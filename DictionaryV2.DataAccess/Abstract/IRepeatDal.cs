using DictionaryV2.Core.DataAccess;
using DictionaryV2.Entity.Concreate;
using System.Collections.Generic;

namespace DictionaryV2.DataAccess.Abstract
{
    public interface IRepeatDal : IEntityRepository<Repeat>
    {
        List<Repeat> GetRepeatsWithDictionaryNotDone();
        void UpdateDoneFlagByDictionaryId(int dictionaryId);
    }
}
