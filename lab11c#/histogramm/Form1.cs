using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace histogramm
{
    public partial class Lab11 : Form
    {
        public Lab11()
        {
            InitializeComponent();
            for (int i = 0; i < 256; i++)
            {
                R[i] = 0;
                G[i] = 0;
                B[i] = 0;
            }
        }
        Image img;
        // основные массивы гистограмм
        int[] R = new int[256];
        int[] G = new int[256];
        int[] B = new int[256];
        // для нового изображения
        int[] RN = new int[256];
        int[] GN = new int[256];
        int[] BN = new int[256];
        // для графиков
        double rsize;
        double gsize;
        double bsize;
        // флаги
        bool flagRed = true;
        bool flagGreen = false;
        bool flagBlue = false;
        // загрузка изображений в поля
        private void buttonLoadimage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);

            if (openFileDialog1.FileName == "openFileDialog1" || openFileDialog1.FileName == "")
                return;

            img = Image.FromFile(openFileDialog1.FileName);
            pictureBoxImage.Image = Line.ResizeImg(img, pictureBoxImage.Width, pictureBoxImage.Height);
            pictureBoxNImage.Image = pictureBoxImage.Image;
        }

        // создаем гистограммы
        private void buttonCreatehistograms_Click(object sender, EventArgs e)
        {
            float scale = (float)numericUpDown1.Value / 100;
            if (openFileDialog1.FileName == "")
                buttonLoadimage_Click(sender, e);
            //первая
            Line.FillArrayRGB(img, ref R, ref G, ref B);
            new Task(() => Line.MakeHistogram(pictureBoxRG, R, Color.Red, scale, ref rsize)).Start();
            new Task(() => Line.MakeHistogram(pictureBoxGG, G, Color.Green, scale, ref gsize)).Start();
            new Task(() => Line.MakeHistogram(pictureBoxBG, B, Color.Blue, scale, ref bsize)).Start();
            // 2 
            Line.FillArrayRGB(pictureBoxNImage.Image, ref RN, ref GN, ref BN);
            new Task(() => Line.MakeHistogram(pictureBoxRNG, RN, Color.Red, scale, ref rsize)).Start();
            new Task(() => Line.MakeHistogram(pictureBoxGNG, GN, Color.Green, scale, ref gsize)).Start();
            new Task(() => Line.MakeHistogram(pictureBoxBNG, BN, Color.Blue, scale, ref bsize)).Start();
        }


        // рисование линий в области гистограммы красного цвета
        private void pictureBoxRNG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bitmap bmp = new Bitmap(pictureBoxRNG.Image);
                // если курсор в области объекта
                if (e.X < pictureBoxRNG.Width && e.X >= 0 && e.Y < pictureBoxRNG.Height && e.Y > 0)
                {
                    RN[e.X] = (int)((pictureBoxRNG.Height - 1 - e.Y) * rsize);// записываем в массив
                    Line.brezenhem(bmp, e.X, e.Y, e.X, 0, Color.Transparent); 
                    Line.brezenhem(bmp, e.X, e.Y, e.X, pictureBoxRNG.Height - 1, Color.Red);// от нижней границы -1 и до положения курсора
                    pictureBoxRNG.Image = bmp;
                }
            }
        }
        // рисование линий в области гистограммы зеленого цвета
        private void pictureBoxGNG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bitmap bmp = new Bitmap(pictureBoxGNG.Image);
                if (e.X < pictureBoxGNG.Width && e.X >= 0 && e.Y < pictureBoxGNG.Height && e.Y > 0)
                {
                    GN[e.X] = (int)((pictureBoxGNG.Height - 1 - e.Y) * gsize);
                    Line.brezenhem(bmp, e.X, e.Y, e.X, 0, Color.Transparent);
                    Line.brezenhem(bmp, e.X, e.Y, e.X, pictureBoxRNG.Height - 1, Color.Green);
                    pictureBoxGNG.Image = bmp;
                }
            }
        }
        // рисование линий в области гистограммы синего цвета
        private void pictureBoxBNG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bitmap bmp = new Bitmap(pictureBoxBNG.Image);
                if (e.X < pictureBoxBNG.Width && e.X >= 0 && e.Y < pictureBoxBNG.Height && e.Y > 0)
                {
                    BN[e.X] = (int)((pictureBoxBNG.Height - 1 - e.Y) * bsize);
                    Line.brezenhem(bmp, e.X, e.Y, e.X, 0, Color.Transparent);
                    Line.brezenhem(bmp, e.X, e.Y, e.X, pictureBoxBNG.Height - 1, Color.Blue);
                    pictureBoxBNG.Image = bmp;
                }
            }
        }

        // выполнем перерисовку
        private void buttonRedraw_Click(object sender, EventArgs e)
        {
            pictureBoxNImage.Image = Line.ResizeImg(Line.redraw(img, RN, GN, BN, flagRed, flagGreen, flagBlue), pictureBoxNImage.Width, pictureBoxNImage.Height);
        }

        //меняем флаг
        private void buttonFlagRed_Click(object sender, EventArgs e)
        {
            flagRed = true;
            flagGreen = false;
            flagBlue = false;
        }
        //меняем флаг
        private void buttonFlagGreen_Click(object sender, EventArgs e)
        {
            flagRed = false;
            flagGreen = true;
            flagBlue = false;
        }
        // меняем флаг
        private void buttonFlagBlue_Click(object sender, EventArgs e)
        {
            flagRed = false;
            flagGreen = false;
            flagBlue = true;
        }
    }
}
