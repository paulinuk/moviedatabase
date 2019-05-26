using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDatabase.Common.Models;
using Newtonsoft.Json;

namespace MovieDatabase.WebApi.Clients
{
    public class ApiControllerAClient : WebApiClient
    {
        public async Task<List<SearchResponse>> SearchAsync(SearchCriteria searchCriteria)
        {
            var content = JsonConvert.SerializeObject(searchCriteria);
            var json = await PostAsync("apicontrollera", "search", content, true).ConfigureAwait(false);
            var result = new List<SearchResponse>();
            if (!json.StartsWith("Error"))
            {
                result = JsonConvert.DeserializeObject<List<SearchResponse>>(json);
            }
            else
            {
                throw new Exception(json);
            }

            return result;


        }
    }
}
