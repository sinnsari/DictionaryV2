using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.DataAccess.Abstract;
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
            
            return View(_engDictionaryService.GetAll().OrderByDescending(x=>x.Id));
        }

        public IActionResult Error() {
            
            return View();
        }
    }
}