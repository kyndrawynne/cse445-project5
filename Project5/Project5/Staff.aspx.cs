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
using System.Xml.Linq;

namespace Project5
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlUserType_SelectedIndexChanged(null, null); // Load users based on the initial selection
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers(); // Reload users based on the selection in dropdown
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text);
        }

        private void LoadUsers(string search = "")
        {
            string filePath = Server.MapPath($"~/App_Data/{ddlUserType.SelectedValue}");
            XDocument doc = XDocument.Load(filePath);
            string elementName = ddlUserType.SelectedValue == "Members.xml" ? "Member" : "StaffMember";

            var usersQuery = doc.Descendants(elementName);

            if (!string.IsNullOrEmpty(search))
            {
                usersQuery = usersQuery.Where(x => x.Element("Username") != null && x.Element("Username").Value.Contains(search));
            }

            var users = usersQuery.Select(x => new {
                Username = x.Element("Username")?.Value,
                Password = x.Element("Password")?.Value
            }).ToList();

            GridViewMembers.DataSource = users;
            GridViewMembers.DataBind();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath($"~/App_Data/{ddlUserType.SelectedValue}");
            XDocument doc = XDocument.Load(filePath);
            string elementName = ddlUserType.SelectedValue == "Members.xml" ? "Member" : "StaffMember";

            XElement newUser = new XElement(elementName,
                new XElement("Username", txtNewUsername.Text),
                new XElement("Password", FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPassword.Text, "SHA1"))
            );
            doc.Element(ddlUserType.SelectedValue.Replace(".xml", "")).Add(newUser);
            doc.Save(filePath);
            LoadUsers(); // Refresh the list to include the new user
            txtNewUsername.Text = ""; // Clear fields after adding
            txtNewPassword.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string usernameToDelete = btn.CommandArgument;
            string filePath = Server.MapPath($"~/App_Data/{ddlUserType.SelectedValue}");
            XDocument doc = XDocument.Load(filePath);
            string elementName = ddlUserType.SelectedValue == "Members.xml" ? "Member" : "StaffMember";

            var userToDelete = doc.Descendants(elementName)
                                  .FirstOrDefault(x => x.Element("Username").Value == usernameToDelete);
            if (userToDelete != null)
            {
                userToDelete.Remove();
                doc.Save(filePath);
                LoadUsers();  // Refresh the list to reflect the deletion
            }
        }

        protected void btnTryIt_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvisibleComponentTesting.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}
