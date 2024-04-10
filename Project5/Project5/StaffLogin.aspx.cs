/*
 Code by Alexis Holland
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml.Linq;

namespace Project5
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // Authenticate the staff member using the provided credentials
            bool authSuccessful = AuthenticateMember(Login1.UserName, Login1.Password);
            e.Authenticated = authSuccessful;

            // If authentication is successful, set authentication cookie and redirect to staff page
            if (authSuccessful)
            {
                bool rememberMe = Login1.RememberMeSet;
                FormsAuthentication.SetAuthCookie(Login1.UserName, rememberMe);
                Response.Redirect("~/Staff.aspx");
            }
            else // If authentication fails, display error message
            {
                lblErrorMessage.Text = "Invalid Username or Password. Please try again.";
                lblErrorMessage.Visible = true;
            }
        }

        private bool AuthenticateMember(string username, string password)
        {
            // Load XML document containing staff member data
            string filePath = HttpContext.Current.Server.MapPath("App_Data/Staff.xml");
            XDocument doc = XDocument.Load(filePath);

            // Query XML document to check if username and password match any staff member
            var query = from member in doc.Descendants("StaffMember")
                        where (string)member.Element("Username") == username &&
                              (string)member.Element("Password") == password
                        select member;

            return query.Any();
        }
    }
}
