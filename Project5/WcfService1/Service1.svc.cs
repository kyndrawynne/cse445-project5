using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
    }
}
