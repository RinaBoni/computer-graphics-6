using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cubeRotate
{
    public partial class Form1 : Form
    {

        private Cube cube;
        private int rotateFlag = -1;
        private int rotateFlagXZ = -1;
        private int rotateFlagYZ = -1;

        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private double centerX;
        private double centerY;
        private double centerZ = 10;

        
        // задаёт точку вокруг которой вращается куб при нажатие мышкой в области pictureBox1
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (rotateFlag == 1)
                return;
            centerX = e.X;
            centerY = e.Y;
            label6.Text = "X " + centerX.ToString();
            label7.Text = "Y " + centerY.ToString();
        }
        // async указывает на то что процедура работает в отдельном потоке и не вызывает останвку всего приложения при работе
        private async void buttonRotateXY_Click(object sender, EventArgs e)
        {
            double grad = double.Parse(textBoxGrad.Text);
            double gradd = grad;
            Cube cube1 = new Cube(cube);
            // флаг включает и выключает вращение куба
            rotateFlag *= -1;
            while (rotateFlag == 1)
            {
                // создаёт отдельный поток await Task.Delay(); ждёт 50 мс и продолжает работу потока
                await Task.Delay(50);
                bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                cube1.rotateCube(bitmap, ref cube1, grad, centerX, centerY, centerZ, rotateFlagXZ, rotateFlagYZ);
                cube1.placeCube(bitmap, Color.Black);
                pictureBox1.Image = bitmap;
                cube1 = new Cube(cube);
                grad += gradd;

            }
        }
        

        // размешение куба на pictureBox1
        private void bPlace_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int z = Convert.ToInt32(textBox3.Text);
            int lenght = Convert.ToInt32(textBox4.Text);
            cube = new Cube(x, y, z, lenght);
            cube.placeCube(bitmap, Color.Black);
            pictureBox1.Image = bitmap;
        }

        // меняет значение флага вращения по xz
        private void bXZ_Click(object sender, EventArgs e)
        {
            rotateFlagXZ *= -1;
            if (rotateFlagXZ == 1) { bXZ.Text = "XZ вкл"; }
            if (rotateFlagXZ == -1) { bXZ.Text = "XZ выкл"; }
        }

        // изменяет состояние флага вращения по yz
        private void bYZ_Click(object sender, EventArgs e)
        {
            rotateFlagYZ *= -1;
            if (rotateFlagYZ == 1) { bYZ.Text = "YZ вкл"; }
            if (rotateFlagYZ == -1) { bYZ.Text = "YZ выкл"; }

        }
    }
}
