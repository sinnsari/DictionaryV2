using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using DictionaryV2.Entity.Models;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult TestTurkish(string type) {

            var engDictionaryList = new List<EngDictionary>();

            if (type == "LastWeek") {
                engDictionaryList = _engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddDays(-7));
            }
            else if (type == "LastMonth") {
                engDictionaryList = _engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddMonths(-1));
            }
            else {
                engDictionaryList = _engDictionaryService.GetAllByRandom();
            }

            var dictionaryModel = new DictionaryModel {
                Dictionaries = engDictionaryList
            };

            return View(dictionaryModel);
        }

        public IActionResult TestEnglish(string type) {

            var engDictionaryList = new List<EngDictionary>();

            if (type == "LastWeek") {
                engDictionaryList = _engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddDays(-7));
            }
            else if (type == "LastMonth") {
                engDictionaryList = _engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddMonths(-1));
            }
            else {
                engDictionaryList = _engDictionaryService.GetAllByRandom();
            }

            var dictionaryModel = new DictionaryModel {
                Dictionaries = engDictionaryList
            };

            return View(dictionaryModel);
        }

        [HttpPost]
        public IActionResult New(EngDictionary entity) {
            entity.InsertDate = DateTime.Now;
            _engDictionaryService.Add(entity);

            return RedirectToAction("New");
        }

        public IActionResult Search(string q) {
            
            var dictionaryModel = new DictionaryModel {
                Dictionaries = _engDictionaryService.GetByFilter(x => x.EngStr.Contains(q) || x.TrStr.Contains(q))
            };

            return View(dictionaryModel);
        }
    }
}