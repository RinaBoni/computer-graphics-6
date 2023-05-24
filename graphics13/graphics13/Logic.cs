using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace graphics13
{
    internal class Logic
    {
        public static void brezenhem(Bitmap bmp, int x1, int y1, int x2, int y2)
        {
            int Px = Math.Abs(x2 - x1);
            int Py = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            int E = Px - Py;
            if (x1 >= 0 && x1 < bmp.Width && y1 >= 0 && y1 < bmp.Height)
                bmp.SetPixel(x1, y1, Color.Black);

            if (x2 >= 0 && x2 < bmp.Width && y2 >= 0 && y2 < bmp.Height)
                bmp.SetPixel(x2, y2, Color.Black);
            while (x1 != x2 || y1 != y2)
            {
                if (x1 >= 0 && x1 < bmp.Width && y1 >= 0 && y1 < bmp.Height)
                    bmp.SetPixel(x1, y1, Color.Black);
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

        public static Bitmap makeShape(Bitmap bmp, List<Vector2> points)
        {
            bmp = new Bitmap(bmp.Width, bmp.Height);
            for(int i = 0; i < points.Count - 1;i++)
            {
                brezenhem(bmp, (int)points[i].X, (int)points[i].Y, (int)points[i + 1].X, (int)points[i + 1].Y);
            }
            brezenhem(bmp, (int)points[0].X, (int)points[0].Y, (int)points[points.Count-1].X, (int)points[points.Count-1].Y);
            return bmp;
        }

        public static Bitmap makeTriangles(Bitmap bmp, List<Vector2> points)
        {
            for (int i = 0; i < points.Count; i += 1)
                for(int j = i + 2; j < points.Count; j+=2)
                    brezenhem(bmp, (int)points[i].X, (int)points[i].Y, (int)points[j].X, (int)points[j].Y);
            return bmp;
        }
    }
}
