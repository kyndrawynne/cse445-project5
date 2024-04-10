/* 
Code by Kyndra Wynne
*/

using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System;

namespace CaptchaGenerator
{
    public class CaptchaService
    {
        // Generates a captcha image and returns its byte array representation
        public byte[] GenerateCaptcha(out string captchaCode)
        {
            captchaCode = GenerateRandomCode(5); // Generate a random captcha code

            // Create a new bitmap image
            using (Bitmap bmp = new Bitmap(200, 50))
            {
                using (Graphics gfx = Graphics.FromImage(bmp)) // Create graphics object for drawing on the bitmap
                {
                    gfx.Clear(Color.White); // Fill the background with white color
                    using (Font font = new Font("Arial", 20, FontStyle.Bold)) // Define font for drawing text
                    {
                        gfx.DrawString(captchaCode, font, new SolidBrush(RandomColor()), 10, 10); // Draw captcha code on the bitmap
                    }
                    DrawRandomLines(gfx, bmp.Width, bmp.Height); // Draw random lines on the bitmap
                }

                using (var ms = new MemoryStream()) // Create memory stream to save the bitmap
                {
                    bmp.Save(ms, ImageFormat.Png); // Save the bitmap as PNG format to the memory stream
                    return ms.ToArray(); // Return the byte array of the bitmap
                }
            }
        }

        // Generates a random alphanumeric code with specified length
        private string GenerateRandomCode(int length)
        {
            Random rand = new Random(); // Initialize random number generator
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Define possible characters for the code
            char[] stringChars = new char[length]; // Initialize array to store characters of the code

            // Generate each character of the code randomly
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[rand.Next(chars.Length)];
            }

            return new string(stringChars); // Return the generated code
        }

        // Generates a random color
        private Color RandomColor()
        {
            Random rand = new Random(); // Initialize random number generator
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)); // Return a random color
        }

        // Draws random lines on the bitmap
        private void DrawRandomLines(Graphics gfx, int width, int height)
        {
            Random rand = new Random(); // Initialize random number generator
            Pen pen = new Pen(RandomColor(), 2); // Define pen for drawing lines with random color
            // Draw 10 random lines
            for (int i = 0; i < 10; i++)
            {
                int x1 = rand.Next(width); // Random x-coordinate for the starting point
                int x2 = rand.Next(width); // Random x-coordinate for the ending point
                int y1 = rand.Next(height); // Random y-coordinate for the starting point
                int y2 = rand.Next(height); // Random y-coordinate for the ending point
                gfx.DrawLine(pen, x1, y1, x2, y2); // Draw the line
            }
        }
    }
}
