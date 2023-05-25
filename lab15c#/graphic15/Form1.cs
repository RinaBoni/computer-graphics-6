using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphic15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int x = 0;
        private int y = 0;


        private void buttonLoadImage1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("Invalid file");
                }
            }
        }

        private void buttonLoadImage2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("Invalid file");
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }

            if(e.Button == MouseButtons.Left
                && (e.X < pictureBox1.Image.Width)
                && (e.Y < pictureBox1.Image.Height))
            {
                x = e.X;
                y = e.Y;

                labelX.Text = x.ToString();
                labelY.Text = y.ToString();
            }
        }

        private void buttonImpose_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null
                || pictureBox2.Image == null)
            {
                return;
            }

            pictureBoxImposed.Image = Logic.Impose(
                new Bitmap(pictureBox1.Image), 
                new Bitmap(pictureBox2.Image), 
                x, y);
        }

        private void pictureBoxImposed_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImposed.Image.Save(saveFileDialog1.FileName);
            }
        }

        
    }
}
