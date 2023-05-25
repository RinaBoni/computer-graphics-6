using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Runtime.Serialization;

namespace GraphicRotate
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        int[] xc = new int[2];
        int[] yc = new int[2];
        int i = 0;
        int flagwork = -1;
        List<Pixel> pixels = new List<Pixel>();
        List<Vector4> lines = new List<Vector4>();

        public class Pixel
        {
            private double x, y;
            public Color color;

            public Pixel(double x, double y)
            {
                setX(x);
                setY(y);
                this.color = Color.Black;
            }

            public void setX(double x)
            {
                this.x = x;
            }
            public void setY(double y)
            {
                this.y = y;
            }
            public double getX() { return x; }
            public double getY() { return y; }
        }

        public void brezenhem(Bitmap bitmap, int x1, int x2, int y1, int y2)
        {
            int Px = Math.Abs(x2 - x1);
            int Py = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            int E = Px - Py;
            bitmap.SetPixel(x1, y1, Color.Black);
            bitmap.SetPixel(x2, y2, Color.Black);
            while (x1 != x2 || y1 != y2)
            {
                bitmap.SetPixel(x1, y1, Color.Black);
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

        private void buildElips(Bitmap bitmap, int x0, int y0, int a, int b)
        {
            double x, y;
            if (a >= b)
            {
                for (x = 0.0; x <= a; x += 0.1)
                {
                    y = Math.Sqrt((1.0 - ((x * x) / (a * a))) * b * b);
                    if (isInBox((int)Math.Round(x0 + x), (int)Math.Round(y0 + y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 + x), (int)Math.Round(y0 + y), Color.Black);
                    pixels.Add(new Pixel(x0 + x, y0 + y));
                    if (isInBox((int)Math.Round(x0 + x), (int)Math.Round(y0 - y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 + x), (int)Math.Round(y0 - y), Color.Black);
                    pixels.Add(new Pixel(x0 + x, y0 - y));
                    if (isInBox((int)Math.Round(x0 - x), (int)Math.Round(y0 + y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 - x), (int)Math.Round(y0 + y), Color.Black);
                    pixels.Add(new Pixel(x0 - x, y0 + y));
                    if (isInBox((int)Math.Round(x0 - x), (int)Math.Round(y0 - y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 - x), (int)Math.Round(y0 - y), Color.Black);
                    pixels.Add(new Pixel(x0 - x, y0 - y));
                }
            }
            else
            {
                for (y = 0.0; y <= b; y += 0.1)
                {
                    x = Math.Sqrt((1.0 - ((y * y) / (b * b))) * a * a);

                    if (isInBox((int)Math.Round(x0 + x), (int)Math.Round(y0 + y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 + x), (int)Math.Round(y0 + y), Color.Black);
                    pixels.Add(new Pixel(x0 + x, y0 + y));
                    if (isInBox((int)Math.Round(x0 + x), (int)Math.Round(y0 - y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 + x), (int)Math.Round(y0 - y), Color.Black);
                    pixels.Add(new Pixel(x0 + x, y0 - y));
                    if (isInBox((int)Math.Round(x0 - x), (int)Math.Round(y0 + y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 - x), (int)Math.Round(y0 + y), Color.Black);
                    pixels.Add(new Pixel(x0 - x, y0 + y));
                    if (isInBox((int)Math.Round(x0 - x), (int)Math.Round(y0 - y), pictureBox1.Width, pictureBox1.Height))
                        bitmap.SetPixel((int)Math.Round(x0 - x), (int)Math.Round(y0 - y), Color.Black);
                    pixels.Add(new Pixel(x0 - x, y0 - y));
                }
            }
        }

        public enum Graphic
        {
            Elips, Line, Hand
        }
        Graphic graphic = Graphic.Line;
        Bitmap bmp;
        public void rotate(double grad, List<Pixel> pixels, List<Vector4> lines, int centerX = -1, int centerY = -1)
        {
            if (centerX == -1 && centerY == -1)
            {
                centerX = pictureBox1.Width / 2;
                centerY = pictureBox1.Height / 2;
            }
            grad /= 180 / Math.PI;
            double x, y, x1, y1;
            double sin = Math.Sin(grad);
            double cos = Math.Cos(grad);
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < pixels.Count; i++)
            {
                x = pixels[i].getX();
                y = pixels[i].getY();
                x = (x - centerX) * cos - (y - centerY) * sin + centerX;
                y = (x - centerX) * sin + (y - centerY) * cos + centerY;
                pixels[i] = new Pixel(x, y);
                if (Math.Round(x) < pictureBox1.Width && Math.Round(x) >= 0 && Math.Round(y) < pictureBox1.Height && Math.Round(y) >= 0)
                {
                    bitmap.SetPixel((int)Math.Round(x), (int)Math.Round(y), pixels[i].color);
                }
            }
            for (int i = 0; i < lines.Count; i++)
            {
                x = lines[i].X;
                y = lines[i].Y;
                x1 = lines[i].Z;
                y1 = lines[i].W;
                x = (x - centerX) * cos - (y - centerY) * sin + centerX;
                y = (x - centerX) * sin + (y - centerY) * cos + centerY;
                x1 = (x1 - centerX) * cos - (y1 - centerY) * sin + centerX;
                y1 = (x1 - centerX) * sin + (y1 - centerY) * cos + centerY;
                lines[i] = new Vector4((float)x, (float)y, (float)x1, (float)y1);
                if (isInBox(x, y, pictureBox1.Width, pictureBox1.Height) && isInBox(x1, y1, pictureBox1.Width, pictureBox1.Height))
                {
                    brezenhem(bitmap, (int)Math.Round(x), (int)Math.Round(x1), (int)Math.Round(y), (int)Math.Round(y1));
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            if (graphic == Graphic.Elips)
                graphic = Graphic.Line;
        }

        private void buttonElips_Click(object sender, EventArgs e)
        {
            if (graphic == Graphic.Line)
                graphic = Graphic.Elips;
        }

        private void buttonRotateLeft_Click(object sender, EventArgs e)
        {
            rotate(-15, pixels, lines);
        }

        private void buttonRotateRight_Click(object sender, EventArgs e)
        {
            rotate(15, pixels, lines);
        }

        private async void buttonAutoRotate_Click(object sender, EventArgs e)
        {
            List<Pixel> pixels2 = new List<Pixel>(pixels);
            List<Vector4> lines2 = new List<Vector4>(lines);
            flagwork *= -1;
            double grad = double.Parse(textBoxGrad.Text);
            double gradd = grad;
            while (flagwork == 1)
            {
                await Task.Delay(5);
                rotate(grad, pixels2, lines2);
                if (gradd > 360)
                {
                    gradd = 0;
                    pixels2 = new List<Pixel>(pixels);
                    lines2 = new List<Vector4>(lines);
                }
                gradd += grad;
            }
        }
        private void pictureBox1MouseHover(object sender, MouseEventArgs e)
        {
            if (graphic != Graphic.Hand)
            {
                if (e.Button == MouseButtons.Left)
                {
                    xc[0] = e.X;
                    yc[0] = e.Y;
                    i++;
                    labelX.Text = "X:" + xc[0].ToString();
                    labelY.Text = "Y:" + yc[0].ToString();

                }
                if (e.Button == MouseButtons.Right)
                {
                    xc[1] = e.X;
                    yc[1] = e.Y;
                    i++;
                    labelX1.Text = "X:" + xc[1].ToString();
                    labelY1.Text = "Y:" + yc[1].ToString();
                }
                if (i == 2)
                {
                    if (graphic == Graphic.Elips)
                    {
                        buildElips(bmp, xc[0], yc[0], Math.Abs(xc[1] - xc[0]), Math.Abs(yc[1] - yc[0]));
                    }
                    if (graphic == Graphic.Line)
                    {
                        brezenhem(bmp, xc[0], xc[1], yc[0], yc[1]);
                        lines.Add(new Vector4(xc[0], yc[0], xc[1], yc[1]));
                    }
                    i = 0;
                    pictureBox1.Image = bmp;
                }
            }

        }
        bool isInBox(double x, double y, int weight, int height)
        {
            return (int)Math.Round(x) < weight && (int)Math.Round(x) >= 0 && (int)Math.Round(y) < height && (int)Math.Round(y) >= 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphic = Graphic.Hand;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (graphic == Graphic.Hand)
            {
                if (e.Button == MouseButtons.Left)
                {
                    bmp.SetPixel(e.X, e.Y, Color.Black);
                    pixels.Add(new Pixel(e.X, e.Y));
                    pictureBox1.Image = bmp;
                }
            }
        }
    }

}