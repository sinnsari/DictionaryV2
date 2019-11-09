using DictionaryV2.Business.Abstract;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Business.Concreate {
    public class RepeatManager : IRepeatService {
        private readonly IRepeatDal _repeatDal;

        public RepeatManager(IRepeatDal repeatDal) {
            _repeatDal = repeatDal;
        }

        public void Add(Repeat entity) {
            _repeatDal.Add(entity);
        }

        public void Delete(Repeat entity) {
            _repeatDal.Delete(entity);
        }

        public List<Repeat> GetAll() {
            return _repeatDal.GetAll();
        }

        public void Update(Repeat entity) {
            _repeatDal.Update(entity);
        }

        public List<Repeat> GetRepeatsWithDictionaryNotDone() {
            return _repeatDal.GetRepeatsWithDictionaryNotDone();
        }

        public void UpdateDoneFlagByDictionaryId(int dictionaryId) {
            _repeatDal.UpdateDoneFlagByDictionaryId(dictionaryId);
        }
    }
}
