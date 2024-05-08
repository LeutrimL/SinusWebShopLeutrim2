using Newtonsoft.Json;
using SinusWebShopLeutrim2.Models;

namespace SinusWebShopLeutrim2.API
{
    public class DataFetcher
    {

        private HttpClient HttpClient { get; }

        public DataFetcher()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://dummyjson.com/");
        }

        public async Task<Root> RetrieveProductData(string endpoint)
        {
            HttpResponseMessage httpResponse = await HttpClient.GetAsync(endpoint);

            if (httpResponse.IsSuccessStatusCode)
            {
                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                Root? parsedData = JsonConvert.DeserializeObject<Root>(jsonResponse);

                if (parsedData != null)
                {
                    return parsedData;
                }
            }
            throw new HttpRequestException("Datahämtning misslyckades!");
        }


    }

}
