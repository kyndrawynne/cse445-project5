using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System;

namespace CaptchaGenerator
{
    public class CaptchaService
    {

        public byte[] GenerateCaptcha(out string captchaCode)
        {
            captchaCode = GenerateRandomCode(5);

            using (Bitmap bmp = new Bitmap(200, 50))
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (Font font = new Font("Arial", 20, FontStyle.Bold))
            {
                gfx.Clear(Color.White);
                gfx.DrawString(captchaCode, font, new SolidBrush(RandomColor()), 10, 10);
                DrawRandomLines(gfx, bmp.Width, bmp.Height);

                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        private string GenerateRandomCode(int length)
        {
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[rand.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private Color RandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        private void DrawRandomLines(Graphics gfx, int width, int height)
        {
            Random rand = new Random();
            Pen pen = new Pen(RandomColor(), 2);
            for (int i = 0; i < 10; i++)
            {
                int x1 = rand.Next(width);
                int x2 = rand.Next(width);
                int y1 = rand.Next(height);
                int y2 = rand.Next(height);
                gfx.DrawLine(pen, x1, y1, x2, y2);
            }
        }
    }
}

