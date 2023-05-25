using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace histogramm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 256; i++)
            {
                R[i] = 0;
                G[i] = 0;
                B[i] = 0;
            }
        }
        Image img;
        int[] R = new int[256];
        int[] G = new int[256];
        int[] B = new int[256];
        // загружаем картинку
        private void buttonLoadimage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);

            if (openFileDialog1.FileName == "openFileDialog1" || openFileDialog1.FileName == "")
                return;

            img = Image.FromFile(openFileDialog1.FileName);
            pictureBox2.Image = ResizeImg(img, pictureBox2.Width, pictureBox2.Height);
        
        }
        public Image ResizeImg(Image b, int nWidth, int nHeight)
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

        private void buttonCreatehistograms_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
                buttonLoadimage_Click(sender, e);
            FillArrayRGB(img);
        }

        private void FillArrayRGB(Image img)
        {
            float scale = (float)numericUpDown1.Value / 100;
            Color color;
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);

            var w = bmp.Width;
            var h = bmp.Height;
            // перебираем картинку по пикселям
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
            // графики строятся в потоках
            // передаем массивы с цветом
            new Task(() => MakeHistogram(pictureBox1, R, Color.Red, scale)).Start();
            new Task(() => MakeHistogram(pictureBox3, G, Color.Green, scale)).Start();
            new Task(() => MakeHistogram(pictureBox4, B, Color.Blue, scale)).Start();
        }
        // отрисовка гистограммы
        // передаем объект, в который передаем битмап, передаем массив по R G B, цвет, скейл
        private void MakeHistogram(PictureBox pictureBox, int[] array, Color color, float scale)
        {
            double max = array.Max();// наибольшее число вхождения одного цвета
            double size = (double)((pictureBox.Height - 1) / max);//максимальный размер от контейнера/ самый высокий график, одно деление
            double value;
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            for(int i = 0; i < array.Count(); i++)
            {
                value = array[i] * size * scale;// берет число цвета * на деление * на масштаб
                if(value > pictureBox.Height - 1)// если масштаб  больше 100, тогда  максимальный размер 
                    value = pictureBox.Height - 1;
                // отрисовываем каждую линию счетчика для гистограммы по высоте
                for(int j = 0; j < value;j++)
                {
                    bmp.SetPixel(i, pictureBox.Height - 1 - j, color);
                }
            }
            pictureBox.Image = bmp;
        }
    }
}
