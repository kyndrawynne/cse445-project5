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
            bool isValidUser = AuthenticateUser(Login1.UserName, Login1.Password);
            e.Authenticated = isValidUser;

            if (isValidUser)
            {
                FormsAuthentication.SetAuthCookie(Login1.UserName, false); // Always false for session cookies
                Response.Redirect("~/Member.aspx"); // Direct to appropriate page
            }
            else
            {
                lblErrorMessage.Text = "Invalid Username or Password. Please try again.";
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