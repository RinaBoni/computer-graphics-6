using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DdaBresenham
{
    public partial class Form1 : Form
    {
        double x1, y1, x2, y2, Px, Py;
        Bitmap ddaBuf, bresBuf;

        public Form1()
        {
            InitializeComponent();
        }

        // ЦДА
        private void notsymetricCDA()
        {
            if ((x1 < x2) || (x1 == x2)) {  //если х1 меньше х2 или равен ему
                Px = x2 - x1;               //ширина прямой
                Py = y2 - y1;               //высота прямой
                ddaBuf.SetPixel((int)Math.Round(x1), (int)Math.Round(y1), Color.Black); //красим первый пиксель
                while (x1 < x2)             //пока не дошли до конца по х
                {
                    x1 = x1 + 1.0;          //увеличиваем координату по х (увеличивам на единицу)
                    y1 = y1 + Py / Px;      //увеличиваем координату по у (увеличиваем по формуле)
                    ddaBuf.SetPixel((int)Math.Round(x1), (int)Math.Round(y1), Color.Black); //красим пиксель
                }
            }
            else    //то же самое что и выше, но строим начиная с х2 (тк она(координата) меньше)
            {
                Px = x1 - x2;
                Py = y1 - y2;
                ddaBuf.SetPixel((int)Math.Round(x2), (int)Math.Round(y2), Color.Black);
                while (x2 < x1)
                {
                    x2 = x2 + 1.0;
                    y2 = y2 + Py / Px;
                    ddaBuf.SetPixel((int)Math.Round(x2), (int)Math.Round(y2), Color.Black);
                }
            }

        }

        // Брезенхем
        private void brezenhem()
        {
            int deltaX = (int)Math.Abs(x2 - x1);    //ширина прямой
            int deltaY = (int)Math.Abs(y2 - y1);    //высота прямой 
            int signX = x1 < x2 ? 1 : -1;           //если х1 меньше х2 знак равен 1, если нет, знак равен -1
            int signY = y1 < y2 ? 1 : -1;           //если у1 меньше у2 знак равен 1, если нет, знак равен -1
            int error = deltaX - deltaY;            //
            bresBuf.SetPixel((int)Math.Round(x2), (int)Math.Round(y2), Color.Black);    //красим последний пиксель
            while (x1 != x2 || y1 != y2)            //пока не дошли до конца или по х, или по у
            {
                bresBuf.SetPixel((int)Math.Round(x1), (int)Math.Round(y1), Color.Black);    //красим пиксель (при первом прохождении первый пиксель прямой, дальше остальные по увеличению)
                int error2 = error * 2;
                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    x1 += signX;                    //увеличиваем координату по х (увеличивам на единицу или минус единицу, в зависимость от того, чему равно signX)
                }
                if (error2 < deltaX)
                {
                    error += deltaX;
                    y1 += signY;                    //увеличиваем координату по у (увеличивам на единицу или минус единицу, в зависимость от того, чему равно signУ)
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)  //кнопка нарисовать цда
        {
            ddaBuf = new Bitmap(DdaPictureBox.Width, DdaPictureBox.Height);

            x1 = int.Parse(x1TextBox.Text);     //получаем из текстбокса х1
            y1 = int.Parse(y1TextBox.Text);     //получаем из текстбокса у1
            x2 = int.Parse(x2TextBox.Text);     //получаем из текстбокса х2
            y2 = int.Parse(y2TextBox.Text);     //получаем из текстбокса у2

            notsymetricCDA();   //рисуем цда

            DdaPictureBox.Image = ddaBuf;
        }

        private void button2_Click(object sender, EventArgs e)  //кнопка нарисовать брезенхем
        {
            bresBuf = new Bitmap(BresenhamPictureBox.Width, BresenhamPictureBox.Height);

            x1 = int.Parse(x1TextBox.Text);     //получаем из текстбокса х1
            y1 = int.Parse(y1TextBox.Text);     //получаем из текстбокса у1
            x2 = int.Parse(x2TextBox.Text);     //получаем из текстбокса х2
            y2 = int.Parse(y2TextBox.Text);     //получаем из текстбокса у2

            brezenhem();    //рисуем брезенхем

            BresenhamPictureBox.Image = bresBuf;
        }
    }
}