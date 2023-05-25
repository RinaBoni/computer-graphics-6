using System.Drawing;
using System.Drawing.Drawing2D;

namespace graphic15
{
    internal class Logic
    {


        public static Image Impose(Bitmap a, Bitmap b, int x, int y)
        {
            Bitmap image;

            var startWidth = a.Width;
            var startHeight = a.Height;

            var endWidth = b.Width;
            var endHeight = b.Height;

            var newWidth = x + endWidth;
            var newHeight = y + endHeight;

            image = new Bitmap(newWidth, newHeight);

            for (int X = 0; X < startWidth; X++)
            {
                for (int Y = 0; Y < startHeight; Y++)
                {
                    image.SetPixel(X, Y, a.GetPixel(X, Y));
                }
            }

            for (int X = 0; X < endWidth; X++)
            {
                for (int Y = 0; Y < endHeight; Y++)
                {
                    image.SetPixel(X + x, Y + y, b.GetPixel(X, Y));
                }
            }

            for (int X = x; X < startWidth; X++)
            {
                for(int Y = y; Y < startHeight; Y++)
                {
                    var newA = (a.GetPixel(X, Y).A + b.GetPixel(X, Y).A) / 2;
                    var newR = (a.GetPixel(X, Y).R + b.GetPixel(X, Y).R) / 2;
                    var newG = (a.GetPixel(X, Y).G + b.GetPixel(X, Y).G) / 2;
                    var newB = (a.GetPixel(X, Y).B + b.GetPixel(X, Y).B) / 2;
                    image.SetPixel(X, Y, 
                        Color.FromArgb(newA, newR, newG, newB));
                }
            }

            return image;
        }
    }
}
