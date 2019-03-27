using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.Entity.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DictionaryController : Controller
    {
        private IEngDictionaryService _engDictionaryService;

        public DictionaryController(IEngDictionaryService engDictionaryService) {
            _engDictionaryService = engDictionaryService;
        }

        [HttpGet("")]
        public List<EngDictionary> Get() {

            return _engDictionaryService.GetAll();
        }

        [HttpPost("new")]
        public IActionResult New([FromBody]EngDictionary entity) {
            entity.InsertDate = DateTime.Now;
            _engDictionaryService.Add(entity);

            return Ok();
        }

        [HttpGet("RandomTurkish")]
        public IActionResult RandomTurkish(string type) {

            if (type == "LastWeek") {
                return Ok(_engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddDays(-7)));
            }
            else if (type == "LastMonth") {
                return Ok(_engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddMonths(-1)));
            }
            else {
                return Ok(_engDictionaryService.GetAllByRandom());
            }
        }

        [HttpGet("RandomEnglish")]
        public IActionResult RandomEnglish(string type) {

            if (type == "LastWeek") {
                return Ok(_engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddDays(-7)));
            }
            else if (type == "LastMonth") {
                return Ok(_engDictionaryService.GetAllByRandomAndDate(DateTime.Now.AddMonths(-1)));
            }
            else {
                return Ok(_engDictionaryService.GetAllByRandom());
            }
        }
    }
}