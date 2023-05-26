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

            //отрисоввка первой картинки
            for (int X = 0; X < startWidth; X++)
            {
                for (int Y = 0; Y < startHeight; Y++)
                {
                    image.SetPixel(X, Y, a.GetPixel(X, Y));
                }
            }

            //отрисовка второй картинки
            //маленькие х и у координаты от которых идет наложение
            for (int X = 0; X < endWidth; X++)
            {
                for (int Y = 0; Y < endHeight; Y++)
                {
                    image.SetPixel(X + x, Y + y, b.GetPixel(X, Y));
                }
            }

            //обраотка зоны наложения
            //складывыет пиксели первой и второй картинки и делит на 2
            for (int X = x; X < startWidth; X++)
            {
                for(int Y = y; Y < startHeight; Y++)
                {
                    var newA = (a.GetPixel(X, Y).A + b.GetPixel(X-x, Y-y).A) / 2;
                    var newR = (a.GetPixel(X, Y).R + b.GetPixel(X-x, Y-y).R) / 2;
                    var newG = (a.GetPixel(X, Y).G + b.GetPixel(X-x, Y-y).G) / 2;
                    var newB = (a.GetPixel(X, Y).B + b.GetPixel(X-x, Y-y).B) / 2;
                    image.SetPixel(X, Y, 
                        Color.FromArgb(newA, newR, newG, newB));//новый цвет
                }
            }

            return image;
        }
    }
}
