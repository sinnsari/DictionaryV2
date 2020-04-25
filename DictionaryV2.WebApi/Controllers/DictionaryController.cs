using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.Entity.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictionaryV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DictionaryController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private IEngDictionaryService _engDictionaryService;

        public DictionaryController(IEngDictionaryService engDictionaryService, ILogger<ValuesController> logger) {
            _engDictionaryService = engDictionaryService;
            _logger = logger;
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public List<EngDictionary> Get() {

            var result = _engDictionaryService.GetAll();

            return result;
        }

        [HttpPost("new")]
        [Authorize(AuthenticationSchemes = "Bearer")]
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