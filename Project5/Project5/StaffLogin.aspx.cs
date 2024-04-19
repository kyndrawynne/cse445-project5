/*
 Code by Alexis Holland
*/
using System;
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
            bool authSuccessful = AuthenticateStaff(Login1.UserName, Login1.Password);
            e.Authenticated = authSuccessful;

            if (authSuccessful)
            {
                bool rememberMe = Login1.RememberMeSet;
                FormsAuthentication.SetAuthCookie(Login1.UserName, rememberMe);
                // Explicitly redirect to the Staff page
                Response.Redirect("~/Staff.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Invalid Username or Password. Please try again.";
                lblErrorMessage.Visible = true;
            }
        }

        private bool AuthenticateStaff(string username, string password)
        {
            string filePath = HttpContext.Current.Server.MapPath("App_Data/Staff.xml");
            XDocument doc = XDocument.Load(filePath);

            var staff = doc.Descendants("StaffMember")
                           .FirstOrDefault(s => (string)s.Element("Username") == username);

            if (staff != null)
            {
                string storedPassword = staff.Element("Password").Value;
                return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1") == storedPassword;
            }
            return false;
        }
    }
}

