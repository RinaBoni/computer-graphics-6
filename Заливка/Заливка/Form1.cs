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

        Pen pen = new Pen(Color.MediumSeaGreen, 3);
        Pen fill_pen = new Pen(Color.MediumPurple, 1);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();
        }

       //рисуем
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

        //включение и выключение заливки
        private void button1_Click(object sender, EventArgs e)
        {
            if (fill)
            {
                fill = false;
                button1.Text = "Заливка выкл";
            }
            else
            {
                fill = true;
                button1.Text = "Заливка вкл";
            }
        }

        private bool areColorValuesEqual(Color clr1, Color clr2)
        {
            return (clr1.ToArgb() == clr2.ToArgb());
        }
        public void Seed(int currentX, int currentY, Color colorBorder, Color colorBack, Bitmap bitmap)
        {
            if ((currentX >= 1) && (currentX < bitmap.Width) && (currentY < bitmap.Height) && (currentY >= 1) && ((areColorValuesEqual(colorBorder, colorBack)) == false) && (areColorValuesEqual(bitmap.GetPixel(currentX, currentY), colorBack) == false))
            {
                bitmap.SetPixel(currentX, currentY, colorBack);//затравка
                int x = currentX - 1; //проверим все, что левее в этой строке
                while ((areColorValuesEqual(bitmap.GetPixel(x, currentY), colorBorder) == false) && (x > 0))
                {
                    if (areColorValuesEqual(bitmap.GetPixel(x, currentY), colorBack) == false) //если пиксель не закрашен, закрашиваем
                    {
                        bitmap.SetPixel(x, currentY, colorBack);
                    }
                    x--;
                }
                int leftX = x + 1; //левая "граница"
                x = currentX + 1; //аналогично с правой границей
                while ((areColorValuesEqual(bitmap.GetPixel(x, currentY), colorBorder) == false) && (x < bitmap.Width - 1))
                {
                    if (areColorValuesEqual(bitmap.GetPixel(x, currentY), colorBack) == false)
                    {
                        bitmap.SetPixel(x, currentY, colorBack);
                    }
                    x++;
                }
                int rightX = x - 1;
                int y = currentY + 1; // проверим строку выше

                int inX = rightX;
                Check(ref inX, leftX, y, colorBorder, colorBack, bitmap);
                x = inX;
                while ((x > 0) && (x < rightX) && (x < bitmap.Width) && (y < bitmap.Height) && (areColorValuesEqual(bitmap.GetPixel(x, y), colorBorder) == false) && (areColorValuesEqual(bitmap.GetPixel(x, y), colorBack) == false))
                {
                    x++;
                }
                if (x != leftX)
                {

                    Seed(x - 1, y, colorBorder, colorBack, bitmap);

                }

                y = currentY - 1;
                inX = rightX;
                Check(ref inX, leftX, y, colorBorder, colorBack, bitmap);
                x = inX;

                while ((x < rightX) && (x < bitmap.Width) && (y < bitmap.Height) && (areColorValuesEqual(bitmap.GetPixel(x, y), colorBorder) == false) && (areColorValuesEqual(bitmap.GetPixel(x, y), colorBack) == false))
                {
                    x++;
                }
                if (x != leftX)
                {
                    Seed(x - 1, y, colorBorder, colorBack, bitmap);
                }

            }
        }
        private void Check(ref int rightX, int leftX, int y, Color colorBorder, Color colorBack, Bitmap bitmap)
        {

            if ((y < bitmap.Height) && (y > 0) && (rightX < bitmap.Width) && (leftX > 0))
            {

                if (areColorValuesEqual(bitmap.GetPixel(rightX, y), colorBorder) == true)
                {
                    rightX = rightX - 4;

                }
                else
                {
                    if (areColorValuesEqual(bitmap.GetPixel(leftX, y), colorBorder) == true) { leftX = leftX + 1; }
                    for (int i = leftX; i <= rightX; i++)
                    {
                        if (areColorValuesEqual(bitmap.GetPixel(i, y), colorBorder) == true)
                        {
                            if (i == rightX) { rightX = rightX - 4; }
                            else
                            {
                                i++;
                            }
                        }
                    }

                }


            }



        }

        //заливка затравкой
        public void filling(int x, int y)
        {
            map.SetPixel(x, y, Color.MediumPurple);
            pictureBox1.Image = map;
            if ((map.GetPixel(x - 1, y).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x - 1, y).ToArgb() != Color.MediumPurple.ToArgb()))
            {
                filling(x - 1, y);
            }
            if ((map.GetPixel(x, y - 1).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x, y - 1).ToArgb() != Color.MediumPurple.ToArgb()))
            {
                filling(x, y - 1);
            }
            if ((map.GetPixel(x + 1, y).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x + 1, y).ToArgb() != Color.MediumPurple.ToArgb()))
            {
                filling(x + 1, y);
            }
            if ((map.GetPixel(x, y + 1).ToArgb() != pen.Color.ToArgb()) & (map.GetPixel(x, y + 1).ToArgb() != Color.MediumPurple.ToArgb()))
            {
                filling(x, y + 1);
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {


            if (fill)
            {
                filling(e.X, e.Y);
                //Seed(e.X, e.Y, Color.MediumSeaGreen, Color.MediumPurple, map);
            }
        }

        //очистка
        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;
        }
    }
}