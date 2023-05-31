using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics;
using System.Net;

namespace ComputeGraphics_7
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pBox.Image = new Bitmap(pBox.ClientSize.Width, pBox.ClientSize.Height);
            PointZero = new Point(pBox.ClientSize.Width / 2, pBox.ClientSize.Height / 2);

        }

        public int n = 8;
        public Pyramid pyramid = new Pyramid();
        Point PointZero;

        Pen pen = new Pen(Color.Black);


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxN.Text) >= 3)
            {
                n = Convert.ToInt32(textBoxN.Text);

                pyramid = new Pyramid(n + 1, new Vector3(pBox.ClientSize.Width / 2, pBox.ClientSize.Height / 2, 0));

                var bitmap = new Bitmap(pBox.Image);
                pyramid.DrawPyramidBitmap(ref bitmap, pen);

                pBox.Image = bitmap;

            }
            else
                MessageBox.Show("N < 3", "Îøèáêà", MessageBoxButtons.OK);
        }


        double Angel;


        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            Angel = trackBarX.Value;

            pyramid.SetPyramid();
            pyramid.RotateX(Angel);

            var bitmap = new Bitmap(pBox.Image);
            pyramid.DrawPyramidBitmap(ref bitmap, pen);
            //pyramid.DrawPyramid(ref bitmap, pen);


            pBox.Image = bitmap;

        }

        private void trackBarY_Scroll(object sender, EventArgs e)
        {
            Angel = trackBarY.Value;

            pyramid.SetPyramid();
            pyramid.RotateY(Angel);

            var bitmap = new Bitmap(pBox.Image);
            pyramid.DrawPyramidBitmap(ref bitmap, pen);



            pBox.Image = bitmap;
        }

        private void trackBarZ_Scroll(object sender, EventArgs e)
        {
            Angel = trackBarZ.Value;

            pyramid.SetPyramid();
            pyramid.RotateZ(Angel);

            var bitmap = new Bitmap(pBox.Image);
            pyramid.DrawPyramidBitmap(ref bitmap, pen);

            pBox.Image = bitmap;
        }


    }
}