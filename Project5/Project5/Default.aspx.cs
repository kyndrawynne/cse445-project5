/* 
 Code by Kyndra Wynne
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Text;

namespace Project5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionStartTime"] != null)
            {
                DateTime startTime = (DateTime)Session["SessionStartTime"];
                lbl_currentTime.Text = "Session started at: " + startTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                lbl_currentTime.Text = "Session has not started.";
            }
        }

        protected void btnMemberPage_Click(object sender, EventArgs e)
        {
            // Redirect to Member page
            Response.Redirect("~/MemberLogin.aspx");
        }

        protected void btnStaffPage_Click(object sender, EventArgs e)
        {
            // Redirect to Staff page
            Response.Redirect("~/StaffLogin.aspx");
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            // Redirect to the Signup page
            Response.Redirect("~/Signup.aspx");
        }

    }
}
