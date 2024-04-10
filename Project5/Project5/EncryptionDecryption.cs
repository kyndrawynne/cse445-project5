/* 
Code by Alexis Holland
*/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Project5
{
    public class EncryptionDecryption
    {
        private readonly string key;
        private readonly string iv;

        // Constructor to initialize key and IV
        public EncryptionDecryption()
        {
            key = "ThisIsA16ByteKey"; // Initialization of encryption key
            iv = "ThisIsAnIV123456"; // Initialization of initialization vector (IV)
        }

        // Method to encrypt text using AES encryption algorithm
        public string Encryption(string textToEncrypt)
        {
            using (Aes aesAlg = Aes.Create()) // Create AES instance
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key); // Set encryption key
                aesAlg.IV = Encoding.UTF8.GetBytes(iv); // Set IV

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV); // Create encryptor

                using (MemoryStream msEncrypt = new MemoryStream()) // Create memory stream to store encrypted data
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) // Create crypto stream for encryption
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) // Create stream writer to write encrypted data
                        {
                            swEncrypt.Write(textToEncrypt); // Write text to be encrypted
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray()); // Convert encrypted data to Base64 string
                }
            }
        }

        // Method to decrypt text using AES decryption algorithm
        public string Decryption(string textToDecrypt)
        {
            using (Aes aesAlg = Aes.Create()) // Create AES instance
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key); // Set encryption key
                aesAlg.IV = Encoding.UTF8.GetBytes(iv); // Set IV

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV); // Create decryptor

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(textToDecrypt))) // Create memory stream from Base64 encoded string
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) // Create crypto stream for decryption
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt)) // Create stream reader to read decrypted data
                        {
                            return srDecrypt.ReadToEnd(); // Read decrypted text
                        }
                    }
                }
            }
        }
    }
}
