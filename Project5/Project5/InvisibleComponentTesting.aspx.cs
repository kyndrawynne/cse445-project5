/* 
Code by Kyndra Wynne
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class InvisibleComponentTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            string input = TextBoxEncrypt.Text;
            EncryptionDecryption encrypter = new EncryptionDecryption();
            string encryptedText = encrypter.Encryption(input);
            LabelEncryptOutput.Text = "Encrypted: " + encryptedText;
        }

        protected void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            string input = TextBoxDecrypt.Text;
            EncryptionDecryption encrypter = new EncryptionDecryption();
            try
            {
                string decryptedText = encrypter.Decryption(input);
                LabelDecryptOutput.Text = "Decrypted: " + decryptedText;
            }
            catch (Exception ex)
            {
                LabelDecryptOutput.Text = "Error decrypting: " + ex.Message;
            }
        }
    }
}