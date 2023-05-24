using System;
using System.Drawing;

namespace cubeRotate
{
    internal class Logic
    {

        // строит линию для ребра
        public static void brezenhem(Bitmap bmp, int x1, int y1, int x2, int y2, Color color)
        {
            int Px = Math.Abs(x2 - x1);
            int Py = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            int E = Px - Py;
            if (x1 >= 0 && x1 < bmp.Width && y1 >= 0 && y1 < bmp.Height)
                bmp.SetPixel(x1, y1, color);

            if (x2 >= 0 && x2 < bmp.Width && y2 >= 0 && y2 < bmp.Height)
                bmp.SetPixel(x2, y2, color);
            while (x1 != x2 || y1 != y2)
            {
                if (x1 >= 0 && x1 < bmp.Width && y1 >= 0 && y1 < bmp.Height)
                    bmp.SetPixel(x1, y1, color);
                int E2 = E * 2;
                if (E2 > -Py)
                {
                    E -= Py;
                    x1 += signX;
                }
                if (E2 < Px)
                {
                    E += Px;
                    y1 += signY;
                }
            }
        }
    }
}
