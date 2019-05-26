using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieDatabase.WebApi.Clients
{
    public class WebApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();


        private static string EstablishUrl(string area, string method, string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                if (parameters[0] != '?')
                {
                    parameters = $"?{parameters}";
                }
            }

            var address = @"http://localhost:51286/api/";

            string result;
            if (address.EndsWith(@"/"))
                result = $"{address}{area}/{method}{parameters}";
            else
                result = $"{address}/{area}/{method}{parameters}";

            return result;
        }

        protected async Task<string> PostAsync(string controller, string method, string parameters, bool isJson)
        {
            var url = EstablishUrl(controller, method, "");
            var content = isJson ? new StringContent(parameters, Encoding.UTF8, "application/json") : new StringContent(parameters);
            try
            {
                var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
                var result = await ProcessResponseAsync(response).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task<string> ProcessResponseAsync(HttpResponseMessage response)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    dynamic item = JsonConvert.DeserializeObject<object>(responseText);
                    var value = item.value;

                    if (value != null)
                    {
                        responseText = (string)value;
                    }
                }
                catch (Exception e)
                {
                    //Ignore any error 
                }

                return responseText;
            }

            return "Error: " + response.StatusCode;
        }

        protected async Task<string> GetAsync(string area, string method, string parameters)
        {
            var url = EstablishUrl(area, method, parameters);
            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
            var result = await ProcessResponseAsync(response).ConfigureAwait(false);

            return result;
        }
    }
}