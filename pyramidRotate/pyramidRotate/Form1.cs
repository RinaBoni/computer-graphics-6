using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pyramidRotate
{
    public partial class Form1 : Form
    {
        private Pen pen;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = this.CreateGraphics();

            pen = new Pen(Color.Black);

        }
        class Pyramid
        {
            public int xc;
            public int yc;
            public int zc;
            public int R;
            public int n;
            public List<vertex> vertices;
            public List<Color> FacesColors;

            public Pyramid(Pyramid pyramid)
            {
                this.xc = pyramid.xc;
                this.yc = pyramid.yc;
                this.zc = pyramid.zc;
                this.R = pyramid.R;
                this.n = pyramid.n;
                copyList(pyramid.vertices);
                this.FacesColors = pyramid.FacesColors;
            }

            public Pyramid(int xc, int yc, int zc, int r, int n)
            {
                this.xc = xc;
                this.yc = yc;
                this.zc = zc;
                R = r;
                this.n = n;
                init();
            }
            private void copyList(List<vertex> vertices)
            {
                this.vertices = new List<vertex>();
                for(int i = 0; i < vertices.Count;i++)
                {
                    this.vertices.Add(new vertex(vertices[i]));
                }
            }
            void init()
            {
                float x;
                float y;
                float z;
                vertices = new List<vertex>();
                FacesColors = new List<Color>();
                Random random= new Random();
                for (int i = 0; i < n; i++)
                {
                    x = xc + R * (float)Math.Cos(0 + (2 * Math.PI * i) / n);
                    z = zc + R * (float)Math.Sin(0 + (2 * Math.PI * i) / n);
                    y = yc;
                    vertices.Add(new vertex(x, y, z));
                    FacesColors.Add(Color.FromArgb(random.Next() % 255, random.Next() % 255, random.Next() % 255));
                }
                FacesColors.Add(Color.FromArgb(random.Next() % 255, random.Next() % 255, random.Next() % 255));
                vertices.Add(new vertex(xc, yc - R, zc));
            }
        }
        private int flagRotate = -1;
        private Bitmap bmp;
        private Pyramid pyramid;
        private List<vertex> vertices = new List<vertex>();
        
        class vertex
        {
            public float x;
            public float y;
            public float z;
            public vertex(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public vertex(vertex vertex)
            {
                this.x = vertex.x;
                this.y = vertex.y;
                this.z = vertex.z;
            }
        }

        private void buttonPlace_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(bmp.Width, bmp.Height);
            g = Graphics.FromImage(bmp);

            g.Clear(Color.White);
            int n = int.Parse(textBoxVertices.Text);
            if (n < 3)
                return;
            int xc = int.Parse(textBoxX.Text);
            if (xc < 0)
                return;
            int yc = int.Parse(textBoxY.Text);
            if (yc < 0)
                return;
            int R = int.Parse(textBoxRadius.Text);
            if (R < 1)
                return;
            int zc = int.Parse(textBoxZ.Text);
            if (zc < 0)
                return;
            pyramid = new Pyramid(xc, yc, zc, R, n);
            flagRotate = -1;
            drawPyramid(pyramid);
            pictureBox1.Image = bmp;
        }

        private void drawPyramid(Pyramid pyramid)
        {
            List<Pixel> zbuf = new List<Pixel>();
            float x1 = pyramid.vertices[0].x;
            float y1 = pyramid.vertices[0].y;
            float z1 = pyramid.vertices[0].z;
            float x3 = pyramid.vertices[pyramid.n].x;
            float y3 = pyramid.vertices[pyramid.n].y;
            float z3 = pyramid.vertices[pyramid.n].z;
            float x2;
            float y2;
            float z2;
            float dist = 1000;
            Vector3 p1,p2,p3;
            p3 = new Vector3(x3, y3, z3);
            for (int i = 1; i < pyramid.n; i++)
            {
                x2 = pyramid.vertices[i].x;
                y2 = pyramid.vertices[i].y;
                z2 = pyramid.vertices[i].z;
                p1 = new Vector3(x1, y1, z1);
                p2 = new Vector3(x2, y2, z2);
                if (IsFaceVisible(p1, p2, p3))
                {
                    PointF pf1 = new PointF(To2dX(x1, z1, dist), To2dY(y1, z1, dist));
                    PointF pf2 = new PointF(To2dX(x2, z2, dist), To2dY(y2, z2, dist));
                    PointF pf3 = new PointF(To2dX(x3, z3, dist), To2dY(y3, z3, dist));
                    Pen b;
                    b = new Pen(pyramid.FacesColors[i]);
                    g.FillPolygon(b.Brush,new PointF[3] { pf1, pf2, pf3 });
                }
                x1 = pyramid.vertices[i].x;
                y1 = pyramid.vertices[i].y;
                z1 = pyramid.vertices[i].z;
            }
            x2 = pyramid.vertices[pyramid.n - 1].x;
            y2 = pyramid.vertices[pyramid.n - 1].y;
            z2 = pyramid.vertices[pyramid.n - 1].z;
            x1 = pyramid.vertices[0].x;
            y1 = pyramid.vertices[0].y;
            z1 = pyramid.vertices[0].z;
            p1 = new Vector3(x1, y1, z1);
            p2 = new Vector3(x2, y2, z2);
            if (IsFaceVisible(p2, p1, p3))
            {
                PointF pf1 = new PointF(To2dX(x1, z1, dist), To2dY(y1, z1, dist));
                PointF pf2 = new PointF(To2dX(x2, z2, dist), To2dY(y2, z2, dist));
                PointF pf3 = new PointF(To2dX(x3, z3, dist), To2dY(y3, z3, dist));
                Pen b;
                b = new Pen(pyramid.FacesColors[0]);
                g.FillPolygon(b.Brush, new PointF[3] { pf1, pf2, pf3 });
            }
            if (IsPyramidBaseFaceVisible)
            {
                for (int i = 0; i < pyramid.n; i++)
                {
                    x2 = pyramid.vertices[i].x;
                    y2 = pyramid.vertices[i].y;
                    z2 = pyramid.vertices[i].z;
                    var pen = new Pen(Color.Black);
                    g.DrawLine(pen, To2dX(x1, z1, dist), To2dY(y1, z1, dist), To2dX(x2, z2, dist), To2dY(y2, z2, dist));
                    x1 = pyramid.vertices[i].x;
                    y1 = pyramid.vertices[i].y;
                    z1 = pyramid.vertices[i].z;
                }
                x2 = pyramid.vertices[pyramid.n-1].x;
                y2 = pyramid.vertices[pyramid.n-1].y;
                z2 = pyramid.vertices[pyramid.n-1].z;
                x1 = pyramid.vertices[0].x;
                y1 = pyramid.vertices[0].y;
                z1 = pyramid.vertices[0].z;
                g.DrawLine(pen, To2dX(x1, z1, dist), To2dY(y1, z1, dist), To2dX(x2, z2, dist), To2dY(y2, z2, dist));
                pouring(bmp, (int)To2dX(pyramid.xc, pyramid.zc, dist), (int)To2dY(pyramid.yc, pyramid.zc, dist), pyramid.FacesColors[pyramid.n]);
            }
        }
        public bool IsPyramidBaseFaceVisible
        {
            get
            {
                return pyramid.zc - pyramid.zc + pyramid.R >= 0;
            }
        }

        class Pixel
        {
            public int x;
            public int y;
            public int z;
            public Pixel(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public Pixel(float x, float y, float z)
            {
                this.x = (int)x;
                this.y = (int)y;
                this.z = (int)z;
            }
            public Pixel(int x, int y){
                this.x = x;
                this.y = y;
                this.z = 0;
            }
        }

        private Bitmap pouring(Bitmap bmp, int x, int y, Color newcolor)
        {
            Stack<Pixel> pixelStack = new Stack<Pixel>();
            Pixel currentPixel;
            pixelStack.Push(new Pixel(x, y));
            Color color1 = bmp.GetPixel(x, y);
            if (color1.ToArgb() == newcolor.ToArgb())
                return bmp;
            while (pixelStack.Count != 0)
            {
                currentPixel = pixelStack.Pop();
                bmp.SetPixel(currentPixel.x, currentPixel.y, newcolor);
                x = currentPixel.x;
                y = currentPixel.y;
                if (x > 1 && x < pictureBox1.Width - 1 && y > 1 && y < pictureBox1.Height - 1)
                {
                    if (bmp.GetPixel(x + 1, y) == color1)
                    {
                        pixelStack.Push(new Pixel(x + 1, y));
                        bmp.SetPixel(x + 1, y, newcolor);
                    }
                    if (bmp.GetPixel(x - 1, y) == color1)
                    {
                        pixelStack.Push(new Pixel(x - 1, y));
                        bmp.SetPixel(x - 1, y, newcolor);
                    }
                    if (bmp.GetPixel(x, y + 1) == color1)
                    {
                        pixelStack.Push(new Pixel(x, y + 1));
                        bmp.SetPixel(x, y + 1, newcolor);

                        if (bmp.GetPixel(x + 1, y + 1) == color1)
                        {
                            pixelStack.Push(new Pixel(x + 1, y + 1));
                            bmp.SetPixel(x + 1, y + 1, newcolor);
                        }

                        if (bmp.GetPixel(x - 1, y + 1) == color1)
                        {
                            pixelStack.Push(new Pixel(x - 1, y + 1));
                            bmp.SetPixel(x - 1, y + 1, newcolor);
                        }
                    }

                    if (bmp.GetPixel(x, y - 1) == color1)
                    {
                        pixelStack.Push(new Pixel(x, y - 1));
                        bmp.SetPixel(x, y - 1, newcolor);

                        if (bmp.GetPixel(x + 1, y - 1) == color1)
                        {
                            pixelStack.Push(new Pixel(x + 1, y - 1));
                            bmp.SetPixel(x + 1, y - 1, newcolor);
                        }

                        if (bmp.GetPixel(x - 1, y - 1) == color1)
                        {
                            pixelStack.Push(new Pixel(x - 1, y - 1));
                            bmp.SetPixel(x - 1, y - 1, newcolor);
                        }
                    }
                }
            }
            return bmp;
        }
        private float To2dX(double x, double z, double dist)
        {
            return (float)Math.Round(x * dist / (z + dist));
        }

        private float To2dY(double y, double z, double dist)
        {
            return (float)Math.Round(y * dist / (z + dist));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pouring(bmp, e.X, e.Y, Color.Aqua);
            pictureBox1.Image = bmp;
        }

        private async void buttonRotate_Click(object sender, EventArgs e)
        {
            flagRotate *= -1;
            double grad = 5;
            double gradd = grad;
            Pyramid pyramid1 = new Pyramid(pyramid);
            while (flagRotate == 1)
            {
                if(gradd >= 360)
                {
                    pyramid1 = new Pyramid(pyramid);
                    gradd = grad;
                }
                await Task.Delay(50);
                pyramidRotate(pyramid1, grad);
                gradd += 5;
                drawPyramid(pyramid1);
                pictureBox1.Image=bmp;
            }
        }

        private void pyramidRotate(Pyramid pyramid, double grad)
        {
            grad /= 180 / Math.PI;
            g.Clear(Color.White);
            float sin = (float)Math.Sin(grad);
            float cos = (float)Math.Cos(0);
            for (int i = 0; i <= pyramid.n ; i++)
            {
                pyramid.vertices[i].x = (pyramid.vertices[i].x - pyramid.xc) * cos + (pyramid.vertices[i].z - pyramid.zc) * sin + pyramid.xc;
                pyramid.vertices[i].z = -(pyramid.vertices[i].x - pyramid.xc) * sin + (pyramid.vertices[i].z - pyramid.zc) * cos + pyramid.zc;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
                bmp = new Bitmap(pictureBox1.Image);
            else
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }
        private bool IsFaceVisible(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            Vector3 o = GetNormal(point1, point2, point3);

            return pyramid.zc - o.Z <= 0;
        }
        private Vector3 GetNormal(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Vector3 A = p2 - p1;
            Vector3 B = p3 - p1;

            return new Vector3
            (
                A.Y * B.Z - A.Z * B.Y,
                A.Z * B.X - A.X * B.Z,
                A.X * B.Y - A.Y * B.X
            );
        }
    }
}
