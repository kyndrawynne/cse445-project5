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
        public static string currentTime = "";
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["SessionCounter"] = 0;
            currentTime = DateTime.Now.ToString();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Int32 counter = ((Int32)Application["SessionCounter"]);
            counter = counter + 1;
            currentTime = DateTime.Now.ToString();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Int32 counter = ((Int32)Application["SessionCounter"]);
            counter = counter - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}