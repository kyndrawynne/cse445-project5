using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml;
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
            bool authSuccessful = AuthenticateMember(Login1.UserName, Login1.Password);
            e.Authenticated = authSuccessful;

            if (authSuccessful)
            {
                bool rememberMe = Login1.RememberMeSet;
                FormsAuthentication.SetAuthCookie(Login1.UserName, rememberMe);
                Response.Redirect("~/Staff.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Invalid Username or Password. Please try again.";
                lblErrorMessage.Visible = true;
            }
        }

        private bool AuthenticateMember(string username, string password)
        {
            string filePath = HttpContext.Current.Server.MapPath("App_Data/Staff.xml");
            XDocument doc = XDocument.Load(filePath);

            var query = from member in doc.Descendants("StaffMember")
                        where (string)member.Element("Username") == username &&
                              (string)member.Element("Password") == password
                        select member;

            return query.Any();
        }
    }
}
