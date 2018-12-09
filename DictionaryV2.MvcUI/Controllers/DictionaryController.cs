using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryV2.MvcUI.Controllers
{
    public class DictionaryController : Controller
    {
        private IEngDictionaryService _engDictionaryService;
        public DictionaryController(IEngDictionaryService engDictionaryService) {
            _engDictionaryService = engDictionaryService;
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult New() {

            return View();
        }

        [HttpPost]
        public IActionResult New(EngDictionary entity) {
            _engDictionaryService.Add(entity);

            return View();
        }
    }
}