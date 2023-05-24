using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showArray(matrixEffect);
        }
        double[,] matrixEffect = new double[4,4];
        Image img;

        private void showArray(double[,] matrix)
        {
            int rowlen = matrix.GetLength(0);

            int collen = matrix.GetLength(1);
            dataGridView1.RowCount = rowlen;
            dataGridView1.ColumnCount = collen;
            for (int i = 0; i < rowlen; i++)
            {
                dataGridView1.Columns[i].Width = 20;
                for (int j = 0; j < collen; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrixEffect[i, j];
                }
            }
        }

        private void buttonRedraw_Click(object sender, EventArgs e)
        {

            if (img == null)
                return;
            Bitmap bmp = new Bitmap(img);
            int Msize = int.Parse(textBoxMSize.Text);
            matrixEffect = new double[Msize, Msize];
            double alpha = double.Parse(textBoxAlpha.Text);
            for (int i = 0; i < Msize; i++)
            {
                for (int j = 0; j < Msize; j++)
                {
                    matrixEffect[i, j] = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            pictureBox2.Image = Redraw(bmp, matrixEffect, Msize, alpha);
        }


        private Bitmap Redraw(Bitmap bmp, double[,] matrixEffect, int Msize, double alpha)
        {
            Bitmap bmpold = new Bitmap(bmp);
            for (int i = 0; i < bmp.Width; i++)
            {
                for(int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, newColor(bmpold, i, j, Msize, matrixEffect, alpha));
                }
            }
            bmp = new Bitmap(ResizeImg(bmp, pictureBox2.Width, pictureBox2.Height));
            return bmp;
        }

        private Color newColor(Bitmap bmp, int x, int y, int Msize, double[,] matrixEffect, double alpha)
        {
            double[,] matrixR = new double[Msize, Msize];
            double[,] matrixG = new double[Msize, Msize];
            double[,] matrixB = new double[Msize, Msize];
            Color newColor;
            for(int i = 0; i < Msize; i++)
            {
                for(int j = 0; j < Msize; j++)
                {
                    if (x - Msize / 2 + i < 0 || y - Msize / 2 + j < 0 || x - Msize / 2 + i >= bmp.Width || y - Msize / 2 + j >= bmp.Height)
                    {
                        matrixR[i, j] = 1;
                        matrixG[i, j] = 1;
                        matrixB[i, j] = 1;
                    }
                    else
                    {
                        matrixR[i, j] = bmp.GetPixel(x - Msize / 2 + i, y - Msize / 2 + j).R;
                        matrixG[i, j] = bmp.GetPixel(x - Msize / 2 + i, y - Msize / 2 + j).G;
                        matrixB[i, j] = bmp.GetPixel(x - Msize / 2 + i, y - Msize / 2 + j).B;
                    }
                }
            }
            int r = (int)(MultiplyMatrix(matrixR, matrixEffect) * alpha);
            int g = (int)(MultiplyMatrix(matrixG, matrixEffect) * alpha); 
            int b = (int)(MultiplyMatrix(matrixB, matrixEffect) * alpha);
            if(r > 255) r = 255; 
            if(r < 0) r = 0;
            if(g > 255) g = 255;
            if(g < 0) g = 0;
            if(b > 255) b = 255;
            if(b < 0) b = 0;
            newColor = Color.FromArgb(r, g, b);
            return newColor;
        }

        private void buttonLoadimg_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);

            if (openFileDialog1.FileName == "openFileDialog1" || openFileDialog1.FileName == "")
                return;

            img = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = ResizeImg(img, pictureBox1.Width, pictureBox1.Height);
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

        public double[,] matrixAlpha(double[,] matrix, double alpha)
        {
            for(int i = 0; i < matrix.GetLength(0);i++)
                for(int j = 0; j < matrix.GetLength(1);j++)
                    matrix[i,j] = matrix[i,j] * alpha;

            return matrix;
        }

        public double MultiplyMatrix(double[,] A, double[,] B)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);

            if (cA != rB)
            {
                throw new Exception("Matrixes can't be multiplied!!");
            }
            else
            {
                double result = 0;

                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        result += A[i, j] * B[i, j];
                    }
                }
                return result;
            }
        }

        private void buttonFilter1_Click(object sender, EventArgs e)
        {
            textBoxMSize.Text = "3";
            textBoxAlpha.Text = "1";
            dataGridView1.Rows[0].Cells[0].Value = 0;
            dataGridView1.Rows[0].Cells[1].Value = -1;
            dataGridView1.Rows[0].Cells[2].Value = 0;
            dataGridView1.Rows[1].Cells[0].Value = -1;
            dataGridView1.Rows[1].Cells[1].Value = 5;
            dataGridView1.Rows[1].Cells[2].Value = -1;
            dataGridView1.Rows[2].Cells[0].Value = 0;
            dataGridView1.Rows[2].Cells[1].Value = -1;
            dataGridView1.Rows[2].Cells[2].Value = 0;
        }

        private void buttonFilter2_Click(object sender, EventArgs e)
        {
            textBoxMSize.Text = "3";
            textBoxAlpha.Text = "0,0625";
            dataGridView1.Rows[0].Cells[0].Value = 1;
            dataGridView1.Rows[0].Cells[1].Value = 2;
            dataGridView1.Rows[0].Cells[2].Value = 1;
            dataGridView1.Rows[1].Cells[0].Value = 2;
            dataGridView1.Rows[1].Cells[1].Value = 4;
            dataGridView1.Rows[1].Cells[2].Value = 2;
            dataGridView1.Rows[2].Cells[0].Value = 1;
            dataGridView1.Rows[2].Cells[1].Value = 2;
            dataGridView1.Rows[2].Cells[2].Value = 1;
        }

        private void buttonFilter3_Click(object sender, EventArgs e)
        {
            textBoxMSize.Text = "3";
            textBoxAlpha.Text = "1";
            dataGridView1.Rows[0].Cells[0].Value = -2;
            dataGridView1.Rows[0].Cells[1].Value = -1;
            dataGridView1.Rows[0].Cells[2].Value = 0;
            dataGridView1.Rows[1].Cells[0].Value = -1;
            dataGridView1.Rows[1].Cells[1].Value = 1;
            dataGridView1.Rows[1].Cells[2].Value = 1;
            dataGridView1.Rows[2].Cells[0].Value = 0;
            dataGridView1.Rows[2].Cells[1].Value = 1;
            dataGridView1.Rows[2].Cells[2].Value = 2;
        }
    }
}
