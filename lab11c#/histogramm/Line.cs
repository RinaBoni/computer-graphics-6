using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace histogramm
{
    internal class Line
    {
        // отрисовка линий
        public static void brezenhem(Bitmap bmp, int x1, int y1, int x2, int y2, Color color)
        {
            int Px = Math.Abs(x2 - x1);
            int Py = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            int E = Px - Py;
            bmp.SetPixel(x1, y1, color);
            bmp.SetPixel(x2, y2, color);
            while (x1 != x2 || y1 != y2)
            {
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
        // перебор пикселей изображения
        public static void FillArrayRGB(Image img, ref int[] R, ref int[] G, ref int[] B)
        {
            Color color;
            Bitmap bmp = new Bitmap(img);

            var w = bmp.Width;
            var h = bmp.Height;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    color = bmp.GetPixel(i, j);
                    R[color.R] += 1;
                    G[color.G] += 1;
                    B[color.B] += 1;
                }
            }
        }
        // для улучшения картинки
        public static Image ResizeImg(Image b, int nWidth, int nHeight)
        {
            Image result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(b, 0, 0, nWidth, nHeight);
                g.Dispose();
            }
            return result;
        }
        // создание гистограмм
        public static void MakeHistogram(PictureBox pictureBox, int[] array, Color color, float scale, ref double size)
        {
            double max = array.Max();
            size = (double)((pictureBox.Height - 1) / max);
            double value;
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            for (int i = 0; i < array.Count(); i++)
            {
                value = array[i] * size * scale;
                if (value > pictureBox.Height - 1)
                    value = pictureBox.Height - 1;
                for (int j = 0; j < value; j++)
                {
                    bmp.SetPixel(i, pictureBox.Height - 1 - j, color);
                }
            }
            size = 1 / size;
            pictureBox.Image = bmp;
        }

        // метод перерисовки
        public static Bitmap redraw(Image img, int[] r, int[] g, int[] b, bool flagR, bool flagG, bool flagB)
        {
            Bitmap bmp = new Bitmap(img);
            Random rnd = new Random();
            int val;
            Color pixel;
            // меняем только по какому-то 1 цвету 
            if (flagR)
            {
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        if (r.Sum() == 0)
                            break;
                        val = rnd.Next(0, 255);
                        while (r[val] == 0)
                        {
                            val = rnd.Next(0, 255);
                        }
                        if (r[val] != 0)
                        {
                            r[val]--;
                            pixel = bmp.GetPixel(i, j);
                            bmp.SetPixel(i, j, Color.FromArgb(val, pixel.G, pixel.B));
                        }
                    }
                }
            }
            if (flagG)
            {
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        if (g.Sum() == 0)
                            break;
                        val = rnd.Next(0, 255);
                        while (g[val] == 0)
                        {
                            val = rnd.Next(0, 255);
                        }
                        if (g[val] != 0)
                        {
                            g[val]--;
                            pixel = bmp.GetPixel(i, j);
                            bmp.SetPixel(i, j, Color.FromArgb(pixel.R, val, pixel.B));
                        }
                    }
                }

            }
            if (flagB)
            {
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        if (b.Sum() == 0)
                            break;
                        val = rnd.Next(0, 255);
                        while (b[val] == 0)
                        {
                            val = rnd.Next(0, 255);
                        }
                        if (b[val] != 0)
                        {
                            b[val]--;
                            pixel = bmp.GetPixel(i, j);
                            bmp.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, val));
                        }
                    }
                }
            }
            return bmp;


        }
    }
}
