/* 
 Code by Alexis Holland
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Project5
{
    public class Global : System.Web.HttpApplication
    {
        // Static variable to hold the current time
        public static string currentTime = "";

        // Event handler for application start
        protected void Application_Start(object sender, EventArgs e)
        {
            // Initialize session counter in application scope
            Application["SessionCounter"] = 0;
            // Set current time
            currentTime = DateTime.Now.ToString();
        }

        // Event handler for session start
        protected void Session_Start(object sender, EventArgs e)
        {
            // Increment session counter
            Int32 counter = ((Int32)Application["SessionCounter"]);
            counter = counter + 1;
            // Update current time
            currentTime = DateTime.Now.ToString();
        }

        // Event handler for beginning of request
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        // Event handler for authentication request
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        // Event handler for application error
        protected void Application_Error(object sender, EventArgs e)
        {

        }

        // Event handler for session end
        protected void Session_End(object sender, EventArgs e)
        {
            // Decrement session counter
            Int32 counter = ((Int32)Application["SessionCounter"]);
            counter = counter - 1;
        }

        // Event handler for application end
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
