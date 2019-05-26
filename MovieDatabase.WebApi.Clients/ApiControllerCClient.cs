using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDatabase.Common.Models;
using Newtonsoft.Json;

namespace MovieDatabase.WebApi.Clients
{
    public class ApiControllerCClient : WebApiClient
    {
        public async Task<List<SearchResponse>> Top5AverageRatingsByUser(int userId)
        {
            var json = await GetAsync("apicontrollerc", "top5averageratingsbyuser", $"userId={userId}").ConfigureAwait(false);
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
