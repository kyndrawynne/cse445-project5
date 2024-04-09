using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace storeFinder
{
    public class Service1 : IService1
    {
        private const string ApiKey = "AIzaSyBQQFAHZn0kNX7KvHU5yC8iEK1krxLmPyE"; // Place your Google API key here
        private const string BaseUrl = "https://places.googleapis.com/v1/places:searchNearby";

        public async Task<NearbySearchResponse> SearchNearbyStoresAsync(double latitude, double longitude, double radius)
        {
            using (var client = new HttpClient())
            {
                var requestUri = BuildRequestUri(latitude, longitude, radius);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync(requestUri, null); // The POST body is empty as parameters are in the URI

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<NearbySearchResponse>(jsonResponse);
                }
                else
                {
                    // Log or handle non-successful response appropriately
                    throw new Exception($"API call failed: {response.ReasonPhrase}");
                }
            }
        }

        private string BuildRequestUri(double latitude, double longitude, double radius)
        {
            var fieldMask = "places.displayName,places.formattedAddress,places.types"; // Adjust based on required fields
            var requestUri = $"{BaseUrl}?key={ApiKey}&location={latitude},{longitude}&radius={radius}&fieldMask={fieldMask}";
            return requestUri;
        }
    }
}
