using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Security.Cryptography;
using System.Text;

namespace Project5
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;

            // Updated hashing logic will be placed here
            string hashedPassword = ComputeHash(password, "SHA256", null);

            // Check if the user already exists
            if (!DoesUserExist(username))
            {
                // Add the new user to the XML file
                AddUserToXml(username, hashedPassword);
            }
            else
            {
                // Show an error message that the user already exists
            }
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


        private bool DoesUserExist(string username)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Members.xml"));

            XmlNode userNode = doc.SelectSingleNode($"//user[username='{username}']");
            return userNode != null;
        }

        private void AddUserToXml(string username, string hashedPassword)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Members.xml"));

            XmlElement newUser = doc.CreateElement("user");
            XmlElement newUsername = doc.CreateElement("username");
            newUsername.InnerText = username;
            XmlElement newPassword = doc.CreateElement("password");
            newPassword.InnerText = hashedPassword;
            XmlElement newRole = doc.CreateElement("role");
            newRole.InnerText = "Member";

            newUser.AppendChild(newUsername);
            newUser.AppendChild(newPassword);
            newUser.AppendChild(newRole);

            doc.DocumentElement.AppendChild(newUser);
            doc.Save(Server.MapPath("~/App_Data/Members.xml"));
        }

    }
}