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

namespace Project5
{
    public partial class Member : System.Web.UI.Page
    {
        private FormsAuthenticationTicket userTicket;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the label text to display the current time
            lbl_currentTime.Text = Global.currentTime;
        }

        protected void btnFindStore_Click(object sender, EventArgs e)
        {
            // Redirect the user to the Google search page
            Response.Redirect("GoogleSearch.aspx");
        }

        protected void btnSavings_Click(object sender, EventArgs e)
        {
            // Redirect the user to the Steps to Savings page
            Response.Redirect("StepsToSavings.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            // Abandon the session to log out the user
            Session.Abandon();
            // Redirect the user to the default page
            Response.Redirect("Default.aspx");
        }
    }
}
