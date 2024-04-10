using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project5.ServiceReference1;

namespace Project5
{
    public partial class GoogleSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Call the WCF service to perform Google search
            ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();
            string searchQuery = txtSearchQuery.Text;
            string result = serviceClient.GoogleSearch(searchQuery);

        }
    }
}