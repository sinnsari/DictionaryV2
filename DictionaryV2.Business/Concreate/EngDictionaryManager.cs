using DictionaryV2.Business.Abstract;
using DictionaryV2.Business.Validation.FluentValidation;
using DictionaryV2.Core.Aspects.PostSharp;
using DictionaryV2.Core.Aspects.PostSharp.CacheAspects;
using DictionaryV2.Core.Aspects.PostSharp.ValidationAspects;
using DictionaryV2.Core.CrossCuttingConcerns.Caching.Microsoft;
using DictionaryV2.Core.CrossCuttingConcerns.Validator.FluentValidator;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Business.Concreate {
    public class EngDictionaryManager : IEngDictionaryService {

        private IEngDictionaryDal _engDictionaryDal;
        public EngDictionaryManager(IEngDictionaryDal engDictionaryDal) {
            _engDictionaryDal = engDictionaryDal;
        }

        [FluentValidatonAspect(typeof(EngDictionaryValidation))]
        public void Add(EngDictionary entity) {
            _engDictionaryDal.Add(entity);
        }

        public void Delete(EngDictionary entity) {
            _engDictionaryDal.Delete(entity);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EngDictionary> GetAll() {
            return _engDictionaryDal.GetAll();
        }

        public List<EngDictionary> GetAllByRandom() {
            return _engDictionaryDal.GetAllByRandom();
        }

        public List<EngDictionary> GetAllByRandomAndDate(DateTime date) {
            return _engDictionaryDal.GetAllByRandomAndDate(date);
        }

        public List<EngDictionary> GetByFilter(Func<EngDictionary,bool> filter) {
            return _engDictionaryDal.GetByFilter(filter);
        }

        public void Update(EngDictionary entity) {
            _engDictionaryDal.Update(entity);
        }
    }
}
