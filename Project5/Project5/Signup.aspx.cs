/*
 Code by Kyndra Wynne
 */
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CaptchaGenerator;

namespace Project5
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Generate a new captcha only on the initial page load
                GenerateCaptcha();
            }
        }

        private void GenerateCaptcha()
        {
            var captchaService = new CaptchaService();
            var captchaBytes = captchaService.GenerateCaptcha(out string captchaCode);
            Session["CaptchaCode"] = captchaCode;

            // Convert captcha bytes to base64 string and set as source for captcha image
            var base64String = Convert.ToBase64String(captchaBytes);
            captchaImage.Src = "data:image/png;base64," + base64String;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            // Regenerate a new captcha image
            GenerateCaptcha();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // Validate captcha code
            if (Session["CaptchaCode"] != null && TextBox1.Text.Equals(Session["CaptchaCode"].ToString(), StringComparison.OrdinalIgnoreCase))
            {
                // Check if all required fields are filled out and passwords match
                if (!string.IsNullOrWhiteSpace(UserName.Text) && !string.IsNullOrWhiteSpace(Password.Text) && Password.Text == ConfirmPassword.Text)
                {
                    // Hash the password before saving to XML
                    string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");

                    // Load XML document for storing members' data
                    string filePath = Server.MapPath("~/App_Data/Members.xml");
                    XDocument doc = XDocument.Load(filePath);

                    // Create new member element and add it to the XML document
                    XElement newMember = new XElement("Member",
                                            new XElement("Username", UserName.Text),
                                            new XElement("Password", hashedPassword));

                    doc.Element("Members").Add(newMember);
                    doc.Save(filePath);

                    // Clear the CAPTCHA session variable after successful signup
                    Session.Remove("CaptchaCode");

                    // Redirect to member page after successful signup
                    Response.Redirect("~/Member.aspx");
                }
                else // Display error message if validation fails
                {
                    errorLabel.Visible = true;
                    errorLabel.Text = "Please ensure all fields are filled out correctly and passwords match.";
                }
            }
            else // Display error message if captcha validation fails
            {
                errorLabel.Visible = true;
                errorLabel.Text = "CAPTCHA validation failed. Please try again.";
                // Generate a new captcha to refresh
                GenerateCaptcha();
            }
        }
    }
}

