using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CaptchaGenerator;
using Project5;

namespace Project5
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        private void GenerateCaptcha()
        {
            var captchaService = new CaptchaService();
            var captchaBytes = captchaService.GenerateCaptcha(out string captchaCode);
            Session["CaptchaCode"] = captchaCode;

            var base64String = Convert.ToBase64String(captchaBytes);
            captchaImage.Src = "data:image/png;base64," + base64String;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Session["CaptchaCode"] != null && TextBox1.Text.Equals(Session["CaptchaCode"].ToString(), StringComparison.OrdinalIgnoreCase))
            {
                if (UserName.Text != "" && Password.Text != "" && Password.Text == ConfirmPassword.Text)
                {
                    EncryptionDecryption encrypter = new EncryptionDecryption();
                    string encryptedPassword = encrypter.Encryption(Password.Text);

                    XDocument doc;
                    string filePath = Server.MapPath("~/App_Data/Member.xml");

                    if (System.IO.File.Exists(filePath))
                    {
                        doc = XDocument.Load(filePath);
                    }
                    else
                    {
                        doc = new XDocument(new XElement("Members"));
                    }

                    XElement newMember = new XElement("Member",
                                            new XElement("Username", UserName.Text),
                                            new XElement("Password", encryptedPassword));

                    doc.Element("Members").Add(newMember);
                    doc.Save(filePath);

                    Response.Redirect("~/Member.aspx");
                }
                else
                {
                    errorLabel.Visible = true;
                    errorLabel.Text = "Please ensure all fields are filled out correctly and passwords match.";
                }
            }
            else
            {
                errorLabel.Visible = true;
                errorLabel.Text = "CAPTCHA validation failed. Please try again.";
                GenerateCaptcha();
            }
        }
    }
}