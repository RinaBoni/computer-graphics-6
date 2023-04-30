using System;
using System.Drawing;
using System.Windows.Forms;

namespace Brazenham_Ellipse_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        SolidBrush red = new SolidBrush(Color.Orange);     //по горизонтали
        SolidBrush blue = new SolidBrush(Color.BlueViolet);   //по вертикали
        int x, y, a, b;

        void putpixel(int x, int y, SolidBrush color) // Рисование пикселя
        {
            g.FillRectangle(color, x, y, 1, 1);
        }

        void pixel4(int x, int y, int _x, int _y, SolidBrush color) // Рисование пикселя для первого квадранта, и, симметрично, для остальных
        {
            putpixel(x + _x, y + _y, color);
            putpixel(x + _x, y - _y, color);
            putpixel(x - _x, y - _y, color);
            putpixel(x - _x, y + _y, color);
        }

        //рисуем
        void draw_ellipse(int x, int y, int a, int b, SolidBrush color_a, SolidBrush color_b)
        {
            int _x = 0; // Компонента x
            int _y = b; // Компонента y
            int a_sqr = a * a; // a^2, a - большая полуось
            int b_sqr = b * b; // b^2, b - малая полуось
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr * ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1, y-1/2)

            /*При перемещении вдоль первого участка дуги мы каждый раз переходим либо по горизонтали,
             * либо по диагонали, критерий перехода напоминает тот, который используется при построении окружности.
             * Находясь в точке (x, y), будем увеличивать значение X на единицу, а затем вычислять значение ∆ = f(x+1, y-1/2).
             * Если это значение меньше нуля, то дополнительная точка (x+1, y-1/2) находится внутри эллипса,
             * следовательно, ближайшая точка растра есть (x+1, y), в противном случае это точка (x+1, y-1) 
             */

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                pixel4(x, y, _x, _y, color_a);
                if (delta < 0) // Переход по горизонтали
                {
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else // Переход по диагонали
                {
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            /*
             На втором участке дуги возможен переход либо по вертикали, либо по диагонали,
            поэтому здесь сначала уменьшаем значение Y, затем вычисляем ∆ = f(x+1/2, y-1),
            и направление перехода выбирается аналогично предыдущему случаю
             */

            while (_y + 1 != 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                pixel4(x, y, _x, _y, color_b);
                if (delta < 0) // Переход по вертикали
                {
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);
                }
                else // Переход по диагонали
                {
                    _y--;
                    delta = delta - 8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y + 3);
                    _x++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Рисование эллипса по нажатию кнопки
        {
            g = Graphics.FromHwnd(pictureBox1.Handle);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //если ничего не ввели, будет выводиться окружность в середине с радиусами 100
            if (textBox1.Text != "")
                x = Convert.ToInt32(textBox1.Text);
            else x = pictureBox1.Width / 2;
            if (textBox2.Text != "")
                y = Convert.ToInt32(textBox2.Text);
            else y = pictureBox1.Height / 2;
            if (textBox3.Text != "")
                a = Convert.ToInt32(textBox3.Text);
            else a = 100;
            if (textBox4.Text != "")
                b = Convert.ToInt32(textBox4.Text);
            else b = 100;
            //рисуем
            draw_ellipse(x, y, a, b, red, blue);
        }
    }
}