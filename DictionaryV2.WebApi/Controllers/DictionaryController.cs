using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.Entity.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryV2.WebApi.Controllers
{
    public class DictionaryController : Controller
    {
        private IEngDictionaryService _engDictionaryService;

        public DictionaryController(IEngDictionaryService engDictionaryService) {
            _engDictionaryService = engDictionaryService;
        }

        [HttpGet]
        public List<EngDictionary> Get() {

            return _engDictionaryService.GetAll();
        }
    }
}