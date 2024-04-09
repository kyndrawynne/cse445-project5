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
            bool authSuccessful = AuthenticateMember(Login1.UserName, Login1.Password);
            e.Authenticated = authSuccessful;

            if (authSuccessful)
            {
                bool rememberMe = Login1.RememberMeSet;
                FormsAuthentication.SetAuthCookie(Login1.UserName, rememberMe);
                Response.Redirect("~/Member.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Invalid Username or Password. Please try again.";
                lblErrorMessage.Visible = true;
            }
        }

        private bool AuthenticateMember(string username, string password)
        {
            string filePath = HttpContext.Current.Server.MapPath("App_Data/Members.xml");
            XDocument doc = XDocument.Load(filePath);

            var query = from member in doc.Descendants("Member")
                        where (string)member.Element("Username") == username &&
                              (string)member.Element("Password") == password
                        select member;

            return query.Any();
        }
    }
}
