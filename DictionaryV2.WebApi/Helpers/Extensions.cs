using DictionaryV2.Entity.Concreate.ApiPaging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DictionaryV2.WebApi.Helpers {
    public static class Extensions {

        public static void AddApplicationError(this HttpResponse response, string message) {

            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddApplicationPageInfo(this HttpResponse response, int totalPage, int totalItems, int currentPage, int pageSize) {
            PagingHeader pagingHeader = new PagingHeader {
                TotalItems = totalItems,
                TotalPage = totalPage,
                CurrentPage = currentPage,
                PageSize = pageSize
            };

            var jsonSerializeSettings = new JsonSerializerSettings();
            jsonSerializeSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("PageInfo", JsonConvert.SerializeObject(pagingHeader, jsonSerializeSettings));
            response.Headers.Add("Access-Control-Expose-Headers","PageInfo");
        }
    }
}
