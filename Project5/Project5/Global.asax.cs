using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Project5
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // I store the start time of the application as an application-level variable.
            Application["AppStartTime"] = DateTime.Now;

            // If I'm using Google Places API for the "Find the Nearest Store" service, I initialize the API key here.
            Application["GooglePlacesAPIKey"] = "YOUR_API_KEY_HERE"; // I need to replace this with the actual API key.

            // Here, I log the application start time for monitoring purposes. This is a simplified version.
            // I would replace this with my actual logging mechanism.
            Log("Application started at " + Application["AppStartTime"].ToString());
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // For each new user session, I initialize a variable to store the start time of that session.
            Session["UserSessionStartTime"] = DateTime.Now;

            // I also set up default values for the radius for store searches and a default step count.
            // These defaults are used by the "Find the Nearest Store" and "Steps to Savings Service" respectively.
            Session["DefaultSearchRadius"] = 5; // Default radius in miles
            Session["DefaultStepsCount"] = 0; // Default step count

            // Similar to application start, I log session starts for auditing or debugging purposes.
            Log("New session started at " + Session["UserSessionStartTime"].ToString());
        }

        // I can add additional methods here for handling other application events, such as Application_End or Session_End.
        protected void Application_Error(object sender, EventArgs e)
        {
            // Here, I handle global application errors. I can log these errors or notify an administrator.
            Exception ex = Server.GetLastError();
            LogError(ex);
        }

        // I use this utility method for logging messages. This is a placeholder; I'd replace it with my actual logging implementation.
        private void Log(string message)
        {
            // Implement logging mechanism here. This is just a placeholder.
            System.Diagnostics.Debug.WriteLine(message);
        }

        // Similarly, I use this method for logging errors, to be replaced with my actual error logging strategy.
        private void LogError(Exception ex)
        {
            // Implement error logging mechanism here. Again, just a placeholder.
            System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
        }
    }