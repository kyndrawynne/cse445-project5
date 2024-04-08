using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Project5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // Assume a method ValidateUser that checks credentials against your XML files or other data store
            bool isValidUser = ValidateUser(Login1.UserName, Login1.Password);
            e.Authenticated = isValidUser;

            if (isValidUser)
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
            else
            {
                // Optionally display an error message
            }
        }

        private bool ValidateUser(string username, string password)
        {
            // Hash the incoming password
            string hashedPassword = ComputeHash(password, "SHA256", null);

            // First, try to validate the user against Members.xml
            if (ValidateUserInXml(Server.MapPath("~/App_Data/Members.xml"), username, hashedPassword))
            {
                return true;
            }

            // If not found in Members.xml, try StaffMembers.xml
            return ValidateUserInXml(Server.MapPath("~/App_Data/StaffMembers.xml"), username, hashedPassword);
        }

        private bool ValidateUserInXml(string filePath, string username, string hashedPassword)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePath))
            {
                doc.Load(filePath);

                // XPath query to find the user node with matching username and password
                XmlNode userNode = doc.SelectSingleNode($"/users/user[username='{username}' and password='{hashedPassword}']");

                if (userNode == null)
                {
                    // If not found in users, try finding in StaffMembers
                    userNode = doc.SelectSingleNode($"/StaffMembers/Staff[Username='{username}' and Password='{hashedPassword}']");
                }

                return userNode != null;
            }
            return false;
        }

        private string ComputeHash(string input, string algorithm, byte[] salt)
        {
            HashAlgorithm hashAlgorithm;
            switch (algorithm.ToUpperInvariant())
            {
                case "SHA256":
                    hashAlgorithm = SHA256.Create();
                    break;
                // Add more cases for different algorithms if needed
                default:
                    throw new ArgumentException("Unsupported hash algorithm");
            }

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            // If implementing salt, append or prepend to inputBytes before hashing
            byte[] hashBytes = hashAlgorithm.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
