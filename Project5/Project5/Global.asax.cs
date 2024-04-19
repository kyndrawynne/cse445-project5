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
        // Event handler for application error
        protected void Application_Error(object sender, EventArgs e)
        {
            // Get the exception object from the server
            Exception ex = Server.GetLastError();

            // Clear the error from the server
            Server.ClearError();

            // Send a simple error message directly to the client
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.Write("It seems something has gone wrong :( Try reloading the page or going back!");
            Response.End();
        }
    }
}
