using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Project5
{
    public partial class Member : System.Web.UI.Page
    {

        private FormsAuthenticationTicket userTicket;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_currentTime.Text = Global.currentTime;

        }

        protected void btnFindStore_Click(object sender, EventArgs e)
        {
            // Placeholder for redirecting
        }

        protected void btnSavings_Click(object sender, EventArgs e)
        {
            // Placeholder for redirecting
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}
