using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Otsechenie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // инициализируем
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        // списко линий
        List<Line> lines = new List<Line>();
        // квадрат, в котором рисуются линии
        Square square;
        // класс квадрат, который хранит вершины квадрата
        class Square
        {
            public int x1, y1, x2, y2;
            public Square(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
        }
        // класс линий, который хранит координаты точек для линий
        class Line
        {
            public int x1, y1, x2, y2;
            public Line(int x1, int y1,int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
        }

        Bitmap bmp;
        int startX;
        int startY;
        PaitingType paitingType;

        // имена 
        enum PaitingType
        {
            Square, Line
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // считывание координат мыши при нажатии
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;
        }
        // поднятие кнопки
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // если выбрана линия, то рисуется линия от зажатия, до отпускания
            if(paitingType == PaitingType.Line)
            {
                lines.Add(new Line(startX, startY, e.X, e.Y));
            }
            // тоже для квадрата
            if (paitingType == PaitingType.Square)
            {
                square = new Square(startX, startY, e.X, e.Y);
            }
            draw(bmp);
        }
        private void brezenhem(Bitmap bmp, int x1, int y1, int x2, int y2)
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
        // метод, который отрисовывает изменения на форме
        private void draw(Bitmap bmp)
        {
            bmp = new Bitmap(bmp.Width, bmp.Height);
            // если квадрат не пустой, тогда рисует  квадрат и проверяет линию на отсечение
            if (square != null)
            {
                drawSquare(bmp, square.x1, square.y1, square.x2, square.y2);
                otsechenie(bmp, square, lines);
            }
            else
                for (int i = 0; i < lines.Count; i++)
                {
                    brezenhem(bmp, lines[i].x1, lines[i].y1, lines[i].x2, lines[i].y2);
                }
            pictureBox1.Image = bmp;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            paitingType = PaitingType.Square;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            paitingType = PaitingType.Line;
        }

        private void drawSquare(Bitmap bmp, int x1, int y1, int x2, int y2)
        {
            brezenhem(bmp, x1, y1, x2, y1);
            brezenhem(bmp, x1, y1, x1, y2);
            brezenhem(bmp, x1, y2, x2, y2);
            brezenhem(bmp, x2, y1, x2, y2);
        }
        // метод, который проверяет линию на вхождение в квадрат
        private void otsechenie(Bitmap bmp, Square square, List<Line> lines)
        {
            // под флаги
            int b00 = 0 , b01 = 0, b02 = 0 , b03 = 0;
            int b10 = 0, b11 = 0, b12 = 0, b13 = 0;
            // вершины  диагонали квадрата
            int xmin = square.x1;// верхний угол
            int ymin = square.y1;

            int xmax = square.x2;// нижний
            int ymax = square.y2;
            // в цикле проверяем все линии
            for(int i = 0; i < lines.Count; i++)
            {
                // берет мершины линии
                int x1 = lines[i].x1;
                int y1 = lines[i].y1;
                int x2 = lines[i].x2;
                int y2 = lines[i].y2;

                makebinary(x1, y1, square, ref b00, ref b01, ref b02, ref b03);
                makebinary(x2, y2, square, ref b10, ref b11, ref b12, ref b13);

                // если все флаги оставить = 0, тогда рисуем линию внутри квадрата
                if(b00 == 0 && b01 == 0 && b02 == 0 && b03 == 0 && b10 == 0 && b11 == 0 && b12 ==0 && b13 == 0)
                {
                    brezenhem(bmp, lines[i].x1, lines[i].y1, lines[i].x2, lines[i].y2);
                }
                // если все флаги =1, тогда не рисуем линию вообще
                else if(b00 == b10 && b01 == b11 && b02 == b12 && b03 == b13)
                {

                }
                // остальные ситуации
                // если линия начинается или заканчивается за квадратом, тогда рисуем  от краев квадрата
                else
                {
                    if(b00 == 1)
                        x1 = square.x1;
                    if(b01 == 1)
                        x1 = square.x2;
                    if (b02 == 1)
                        y1 = square.y1;
                    if(b03 == 1)
                        y1 = square.y2;
                    if (b10 == 1)
                        x2 = square.x1;
                    if (b11 == 1)
                        x2 = square.x2;
                    if (b12 == 1)
                        y2 = square.y1;
                    if (b13 == 1)
                        y2 = square.y2;
                    brezenhem(bmp, x1, y1, x2, y2);
                }

            }
        }
        // Расстановка флагов, проверка на попадание в квадрат
        private void makebinary(int x1, int y1, Square square, ref int b0, ref int b1, ref int b2, ref int b3)
        {
            // вершины квадрата
            int xmin = square.x1;
            int ymin = square.y1;
            int xmax = square.x2;
            int ymax = square.y2;
            
            if (x1 >= xmin)     // если точка входит по х
                b0 = 0;
            else if (x1 < xmin) // если точка меньше по х
                b0 = 1;

            if (x1 <= xmax)     // если точка попала по х
                b1 = 0;
            else if (x1 > xmax) // если точка больше по х
                b1 = 1;

            if (y1 >= ymin)     // если точка входит по у
                b2 = 0;
            else if (y1 < ymin) // если точка меньше по у
                b2 = 1;

            if (y1 <= ymax)     // если точка попала по у
                b3 = 0;
            else if (y1 > ymax) // если точка больше по у
                b3 = 1;
        }

        // очистка всего поля
        private void buttonClear_Click(object sender, EventArgs e)
        {
            lines = new List<Line>();
            square = null;
            draw(bmp);
        }
    }
}
