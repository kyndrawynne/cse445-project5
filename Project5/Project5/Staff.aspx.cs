/* 
 Code by Alexis Holland
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTryIt_Click(object sender, EventArgs e)
        {
            // Redirect to the Invisble Component Testing Page
            Response.Redirect("InvisibleComponentTesting.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut(); // Ensure the authentication ticket is invalidated
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}