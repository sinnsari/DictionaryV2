using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.Entity.Concreate;
using DictionaryV2.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryV2.MvcUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IEngDictionaryService _engDictionaryService;
        public AdminController(IEngDictionaryService engDictionaryService) {

            _engDictionaryService = engDictionaryService;
        }

        public IActionResult Index() {

            var dictionaryModel = new DictionaryModel {
                Dictionaries = _engDictionaryService.GetAll().OrderByDescending(x => x.Id).ToList()
            };

            return View(dictionaryModel);
        }

        public IActionResult Edit(int id) {

            var obj = _engDictionaryService.GetByFilter(x => x.Id == id).FirstOrDefault();
            
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(EngDictionary engDictionary) {

            var obj = _engDictionaryService.GetByFilter(x => x.Id == engDictionary.Id).FirstOrDefault();
            engDictionary.InsertDate = obj.InsertDate;

            _engDictionaryService.Update(engDictionary);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {

            var obj = _engDictionaryService.GetByFilter(x => x.Id == id);
            if(obj != null && obj.Count > 0) {
                _engDictionaryService.Delete(obj.FirstOrDefault());
            }

            return RedirectToAction("Index");
        }
    }
}