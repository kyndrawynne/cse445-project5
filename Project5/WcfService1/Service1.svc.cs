using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.MapsPlaces.v1;
using Google.Apis.MapsPlaces.v1.Data;
using Google.Apis.Services;
using System.Text;
using System.Configuration;



namespace WcfService1
{
    public class Service1 : IService1
    {


        // Service by Alexis Holland 
        public string StepsToSavings(int steps, decimal gasPrice)

        {
            const double STEPS_PER_MILE = 2500.0; // Average steps per mile
            const double MILES_PER_GALLON = 25; // Average fuel efficiency


            // Convert steps to miles
            double distance = steps / STEPS_PER_MILE;

            // Calculate savings based on miles per gallon
            double gallonsSaved = distance / MILES_PER_GALLON;
            double savings = gallonsSaved * (double)gasPrice;


            // Format and return the result as a string
            return $"Distance walked: {distance:F2} miles, Money saved on gas: ${savings:F2}";

        }

        // Service by Kyndra Wynne
        public string GoogleSearch(string query)
        {
            try
            {
                // Construct the search URL with the provided query string
                string searchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(query)}";

                // Open the default web browser with the search URL
                Process.Start(searchUrl);

                // Return success message
                return "Web browser opened with Google search page.";
            }
            catch (Exception ex)
            {
                // Return error message if an exception occurs
                return $"An error occurred: {ex.Message}";
            }
        }

        /*
        private const string API_KEY = "AIzaSyBQQFAHZn0kNX7KvHU5yC8iEK1krxLmPyE";

        public string GetNearbyPlaces(string location)
        {

            // Parse latitude and longitude from the 'location' string 
            var coordinates = location.Split(',');
            if (coordinates.Length != 2)
            {
                return "Invalid location format. Please provide as 'latitude,longitude'";
            }

            double latitude = double.Parse(coordinates[0]);
            double longitude = double.Parse(coordinates[1]);

            // Fixed Search Type and Radius
            string type = "health_food_store";
            int radius = 15000;

            var client = new MapsPlacesService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredential.GetApplicationDefault().CreateScoped(MapsPlacesService.Scope.PlaceReadonly),
                ApiKey = API_KEY
            });

            var request = new NearbySearchRequest();
            request.Location = new Location()
            {
                Latitude = latitude,
                Longitude = longitude
            };
            request.Radius = radius;
            request.Type = type;

            try
            {
                var response = client.NearbySearch.List(request).Execute();

                StringBuilder sb = new StringBuilder();
                foreach (var place in response.Results)
                {
                    sb.AppendLine($"{place.Name} - {place.Vicinity}");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return $"An error occurred during the Places search: {ex.Message}";
            }
        }*/
    }
}
