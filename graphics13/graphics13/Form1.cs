using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            points = new List<Vector2>();
        }
        Bitmap bmp;
        List<Vector2> points;
        int x;
        int y;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(new Vector2(e.X, e.Y));
                if (x != 0 && y != 0)
                {
                    bmp = Logic.makeShape(bmp, points);
                    bmp = Logic.makeTriangles(bmp, points);

                    pictureBox1.Image= bmp;
                }
                x = e.X; y = e.Y;

            }
            if(e.Button == MouseButtons.Right)
            {
                points.Clear();
                bmp = new Bitmap(bmp.Width, bmp.Height);

                pictureBox1.Image = bmp;
                x = 0; y = 0;
            }
        }
    }
}
