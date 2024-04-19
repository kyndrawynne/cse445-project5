/*
 Code by Kyndra Wynne
*/
using System;
using System.Linq;
using System.Web.UI;
using System.Web.Security;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using System.Web;

namespace Project5
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // Authenticate the member or staff using the provided credentials
            bool authSuccessful = AuthenticateUser(Login1.UserName, Login1.Password);
            e.Authenticated = authSuccessful;

            // If authentication is successful, set authentication cookie and redirect to member page
            if (authSuccessful)
            {
                bool rememberMe = Login1.RememberMeSet;
                FormsAuthentication.SetAuthCookie(Login1.UserName, rememberMe);
                Response.Redirect("~/Member.aspx");
            }
            else // If authentication fails, display error message
            {
                lblErrorMessage.Text = "Invalid Username or Password. Please try again.";
                lblErrorMessage.Visible = true;
            }
        }

        // Method to authenticate the user by checking username and password against stored member or staff data
        private bool AuthenticateUser(string username, string password)
        {
            // First try to authenticate as a member
            if (AuthenticateMember(username, password, "Members.xml"))
            {
                return true;
            }
            // If not found in Members.xml, try Staff.xml
            return AuthenticateMember(username, password, "Staff.xml");
        }

        private bool AuthenticateMember(string username, string password, string fileName)
        {
            string filePath = HttpContext.Current.Server.MapPath($"App_Data/{fileName}");
            XDocument doc = XDocument.Load(filePath);

            string elementName = fileName == "Members.xml" ? "Member" : "StaffMember";

            var query = from user in doc.Descendants(elementName)
                        where (string)user.Element("Username") == username &&
                              (string)user.Element("Password") == FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1")
                        select user;

            return query.Any();
        }
    }
}