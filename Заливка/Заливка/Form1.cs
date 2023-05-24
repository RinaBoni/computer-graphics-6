namespace Заливка
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }

        private bool isMouse = false;
        private bool fill = false;

        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;

            public ArrayPoints(int size)
            {
                if (size <= 0) { size = 2; }
                points = new Point[size];
            }
            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }
            public void ResetPoints()
            {
                index = 0;
            }
            public int GetCountPoints()
            {
                return index;
            }
            public Point[] GetPoints()
            {
                return points;
            }
        }

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);
        }

        private ArrayPoints arrayPoints = new ArrayPoints(2);
        Bitmap map = new Bitmap(100, 100);
        Graphics graphics;

        Pen pen = new Pen(Color.Red, 3);
        Pen fill_pen = new Pen(Color.Black, 1);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse) { return; }

            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox1.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fill)
            {
                fill = false;
            }
            else
            {
                fill = true;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            void filling(int x, int y)
            {
                map.SetPixel(x, y, Color.Black);
                pictureBox1.Image = map;
                if ((map.GetPixel(x - 1, y).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x - 1, y).ToArgb() != Color.Black.ToArgb()))
                {
                    filling(x - 1, y);
                }
                if ((map.GetPixel(x, y - 1).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x, y - 1).ToArgb() != Color.Black.ToArgb()))
                {
                    filling(x, y - 1);
                }
                if ((map.GetPixel(x + 1, y).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x + 1, y).ToArgb() != Color.Black.ToArgb()))
                {
                    filling(x + 1, y);
                }
                if ((map.GetPixel(x, y + 1).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x, y + 1).ToArgb() != Color.Black.ToArgb()))
                {
                    filling(x, y + 1);
                }
            }

            if (fill)
            {
                filling(e.X, e.Y);
            }
        }
    }
}