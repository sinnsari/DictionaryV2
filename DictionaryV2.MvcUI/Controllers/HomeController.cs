using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryV2.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private IEngDictionaryService _engDictionaryService;
        public HomeController(IEngDictionaryService engDictionaryService) {

            _engDictionaryService = engDictionaryService;
        }
        public IActionResult Index() {

            var dictionaryModel = new DictionaryModel {
                Dictionaries = _engDictionaryService.GetAll().OrderByDescending(x => x.Id).ToList()
            };

            return View(dictionaryModel);
        }

        public IActionResult Error() {
            
            return View();
        }
    }
}