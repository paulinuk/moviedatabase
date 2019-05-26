using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDatabase.Common.Models;
using Newtonsoft.Json;

namespace MovieDatabase.WebApi.Clients
{
    public class ApiControllerDClient : WebApiClient
    {
        public async Task<List<SearchResponse>> AddOrUpdateRatingAsync(int userId, int movieId, decimal rating)
        {
            var parameters = $"userId={userId}&movieId={movieId}&rating={rating}";
            var json = await GetAsync("apicontrollerd", "addorupdaterating", parameters).ConfigureAwait(false);
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
