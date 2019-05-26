using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDatabase.Common.Models;
using Newtonsoft.Json;

namespace MovieDatabase.WebApi.Clients
{
    public class ApiControllerBClient : WebApiClient
    {
        public async Task<List<SearchResponse>> Top5AverageRatingsAsync()
        {
            var json = await GetAsync("apicontrollerb", "top5averageratings", string.Empty).ConfigureAwait(false);
            List<SearchResponse> result;
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
