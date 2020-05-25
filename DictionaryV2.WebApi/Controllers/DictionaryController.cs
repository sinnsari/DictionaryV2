using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.Entity.Concreate;
using DictionaryV2.WebApi.Helpers;
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

            var result = _engDictionaryService.GetAll().OrderByDescending(x=> x.InsertDate).ToList();

            return result;
        }

        [HttpGet("GetByPaging")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetByPaging([FromQuery]PagingParam pagingParam) {

            var result = _engDictionaryService.GetByPaging(pagingParam);

            Response.AddApplicationPageInfo(result.TotalPage, result.TotalItems, pagingParam.PageNumber, pagingParam.PageSize);

            return Ok(result);
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

        [HttpGet("Search")]
        public IActionResult Search(string search) {
            var searchList = _engDictionaryService.GetByFilter(x => x.TrStr.Contains(search) || x.EngStr.Contains(search));

            return Ok(searchList);
        }

        [HttpPut("edit")]
        public IActionResult Edit(int id, [FromBody]EngDictionary engDictionary) {
            try {
                var updatedObj = _engDictionaryService.GetByFilter(x => x.Id == id).FirstOrDefault();
                if (updatedObj == null) {
                    return NotFound("Dictionary not found");
                }

                updatedObj.TrStr = engDictionary.TrStr;
                updatedObj.EngStr = engDictionary.EngStr;

                _engDictionaryService.Update(updatedObj);
                return Ok();
            }
            catch (Exception ex) {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id) {
            try {

                var deletedObj = _engDictionaryService.GetByFilter(x => x.Id == id);
                if (deletedObj == null || deletedObj.Count == 0) {
                    return NotFound("Dictionary not found");
                }

                _engDictionaryService.Delete(deletedObj.FirstOrDefault());
                return Ok();
            }
            catch (Exception ex) {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id) {
            var dictionary = _engDictionaryService.GetByFilter(x => x.Id == id).FirstOrDefault();
            if (dictionary == null) {
                return NotFound("Dictionary not found");
            }

            return Ok(dictionary);
        }
    }
}