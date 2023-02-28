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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        Bitmap ddaBuf, bresBuf;

        public Form1()
        {
            InitializeComponent();
        }

        // ЦДА
        private void notsymetricCDA()
        {
            Px = x2 - x1;
            Py = y2 - y1;
            ddaBuf.SetPixel((int)Math.Round(x1), (int)Math.Round(y1), Color.Black);
            while (x1 < x2)
            {
                x1 = x1 + 1.0;
                y1 = y1 + Py / Px;
                ddaBuf.SetPixel((int)Math.Round(x1), (int)Math.Round(y1), Color.Black);
            }

        }

        // Брезенхем
        private void brezenhem()
        {
            int deltaX = (int)Math.Abs(x2 - x1);
            int deltaY = (int)Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            int error = deltaX - deltaY;
            bresBuf.SetPixel((int)Math.Round(x2), (int)Math.Round(y2), Color.Black);
            while (x1 != x2 || y1 != y2)
            {
                bresBuf.SetPixel((int)Math.Round(x1), (int)Math.Round(y1), Color.Black);
                int error2 = error * 2;
                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    x1 += signX;
                }
                if (error2 < deltaX)
                {
                    error += deltaX;
                    y1 += signY;
                }
            }
        }

        private void buttonDda_Click(object sender, EventArgs e)
        {
            ddaBuf = new Bitmap(DdaPictureBox.Width, DdaPictureBox.Height);
/*            bresBuf = new Bitmap(BresenhamPictureBox.Width, BresenhamPictureBox.Height);
*/
            x1 = int.Parse(x1TextBox.Text);
            y1 = int.Parse(y1TextBox.Text);
            x2 = int.Parse(x2TextBox.Text);
            y2 = int.Parse(y2TextBox.Text);

            notsymetricCDA();
/*            brezenhem();
*/
            DdaPictureBox.Image = ddaBuf;
/*            BresenhamPictureBox.Image = bresBuf;
*/        }

        private void buttonBres_Click(object sender, EventArgs e)
        {
/*            ddaBuf = new Bitmap(DdaPictureBox.Width, DdaPictureBox.Height);
*/         bresBuf = new Bitmap(BresenhamPictureBox.Width, BresenhamPictureBox.Height);

            x1 = int.Parse(x1TextBox.Text);
            y1 = int.Parse(y1TextBox.Text);
            x2 = int.Parse(x2TextBox.Text);
            y2 = int.Parse(y2TextBox.Text);

/*            notsymetricCDA();
*/          brezenhem();

/*            DdaPictureBox.Image = ddaBuf;
*/         BresenhamPictureBox.Image = bresBuf;

        }
    }
}