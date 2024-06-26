using System.Security.Cryptography.X509Certificates;

namespace mal
{
    public partial class Form1 : Form
    {
        Bitmap image;//�������� �� ������� ����� ��������

        class PointD
        {
            public double X;
            public double Y;
        }

        struct PointDWithP
        {
            public PointD point;//����� ������� ����� ��������
            public int pOffset;//����� ������������ ������� rgb
        }

        //��� ����� ����������, ������� ������, ����� �������� ����������� � ������ ������, cX � �Y - ���������� ������ ������
        /*double cX = 0;
        double cY = 0;*/
        PointD center = new PointD { X = 0, Y = 0 };
        double scale = 300;//��� ����������
        public Form1()
        {
            InitializeComponent();
            InitImage();
            Draw();

            //���������� ��� ���������� � ������� �������� �����
            pbMain.MouseWheel += PbMain_MouseWheel;
        }

        private void PbMain_MouseWheel(object? sender, MouseEventArgs e)
        {
            scale *= e.Delta > 0 ? 1.5 : 1.0 / 1.5;
            Draw();
        }

        //������������� �������
        void InitImage()
        {
            image = new Bitmap(
                pbMain.Width,
                pbMain.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb//����� ���� ������� ������ ������� ��������
            );
            pbMain.Image = image;
        }

        //��� ��������� ������� ����
        private void pbMain_Resize(object sender, EventArgs e)
        {
            InitImage();
            Draw();
        }

        //��� ������ ������� ���������
        //�� ����� ����� � ����������� �����������, ��������� � ���� ���������� (���������� ������)
        PointD ToLocal(Point point)
        {
            return ToLocal(point.X, point.Y);
        }

        PointD ToLocal(int x, int y)
        {
            return ToLocal(x, y, image.Width, image.Height);
        }


        //����� �� ���� ���������� � ��������, ������� ���� �� �����. ��������� � ��� ������ ����������� ����� (���� ��� X = (double)(x - (double)image.Width / 2) / scale + center.X,)
        PointD ToLocal(int x, int y, int width, int height)
        {
            return new PointD
            {
                X = (double)(x - (double)width / 2) / scale + center.X,
                Y = -(double)(y - (double)height / 2) / scale + center.Y,
            };
        }

        void FillRgbPixel(int x, int y, int n, byte[] rgb, int width, int height)
        {

            //��������� ����� �����(??)(�� �� � ������� rgb) ���� ���������� � � �
            int p = (y * width + x) * 4;//� - ������ ������, ������ ������ ����� ����� image.widht, x - �������� ������ ������, �� ���� ������� ���������� 4 �����

            //�0, y0 - ����� �� ������� �� �������� ������/�� ������� �������� 
            var xy0 = ToLocal(x, y, width, height);

            //������ ��������� �����(�� ����������� �����, ������ ���������� � ����� ����� ������ ������)  
            var xn = xy0.X; var yn = xy0.Y;
            double xn_1, yn_1;
            bool ok = true; //��� ������� ��� ����� ������

            //��������� ������ �� ��������� �������������� ������ � �������, ���� i ������������ ������ � n �� ������ ���� ������� � �����������, ���� ����� � 0 �� ���� ������� � ������
            //������ ���������
            int i;
            for (i = 0; i < n; i++)
            {
                //����������� �������
                xn_1 = xn * xn - yn * yn + xy0.X;
                yn_1 = 2 * xn * yn + xy0.Y;
                //���� ����� �� ����������� ���������, ������� �� �����
                if (xn_1 * xn_1 + yn_1 * yn_1 > 4)
                {
                    ok = false;
                    break;
                }
                xn = xn_1;
                yn = yn_1;
            }

            if (ok)
            {
                //������ �������� ����� ����� ���� ��������, ��������� �������� �� ����� ����� - ������������
                rgb[p] = 179;//�����
                rgb[p + 1] = 107;//�������
                rgb[p + 2] = 0;//�������  
                rgb[p + 3] = 255; //�����
            }
            else
            {
                //���������� �������� � ������
                double k = 1 - (double)i / n;

                //������ �������� ����� ����� ���� ��������, ��������� �������� �� ����� ����� - ������������
                rgb[p] = (byte)((1 - k) * 76 + k * 179);//�����
                rgb[p + 1] = (byte)((1 - k) * 148 + k * 107);//�������
                rgb[p + 2] = (byte)((1 - k) * 255 + k * 0);//�������  
                rgb[p + 3] = 255; //�����
            }
        }

        //���������� ��������� ������������
        void Draw()
        {
            //���������� �� ������ � ������ ������ ������� ������
            //���������� ��������������� ������
            var data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),//��������� ��������� �����������
                 System.Drawing.Imaging.ImageLockMode.ReadWrite,//� ������ ������ ��������� 
                 System.Drawing.Imaging.PixelFormat.Format32bppArgb//��������� ������ ������������� �����������
                );

            //������ �� ������� ������ Skan0 ������ ������� ����� �����������
            IntPtr ptr = data.Scan0;
            //�� �� ����� ����� � �������� �� � ������, ������� ����� ����������� ��������� ������, ������ ������ ������� ����� ������� �����������
            int count = Math.Abs(data.Stride) * image.Height;//Stride - ���������� ���� � ����� ������ 
            //������� ������ (���������� ����) ��� ���� ������ 
            byte[] rgb = new byte[count];

            //�������� �������� rgb � ������ (������, ����, ������, �����)
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgb, 0, count);

            //��� ����������� ����������� �� ����� �������
            int n = tbN.Value;  //tbN ����������� ��������� �������

            //��������� ���������
            List<Point> points = new();

            //���������� �� ���� ������ ����������� � ���-�� �������(���������� ������)
            for (var y = 0; y < image.Height; ++y)
            {
                for (var x = 0; x < image.Width; ++x)
                {

                    points.Add(new Point(x, y));
                    /*points.Add(new PointDWithP
                    {
                        pOffset = p,
                        point = xy0
                    });
*/

                }
            }

            int width = image.Width; int height = image.Height;

            //�������� ������, �������� �� ���� ����� �� ��� ������� �������� � ������ �������� �������
            Parallel.ForEach(points, p =>
            {
                FillRgbPixel(p.X, p.Y, n, rgb, width, height);
            });


            //������� ������ ������ � ������� (� ������)
            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, ptr, count);
            //������������ ������� ������ (�����������)
            image.UnlockBits(data);
            //������� ����������� ����������
            pbMain.Invalidate();
        }


        //��� �������� ���� � ����������� ������� ���������� ����
        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            var point = ToLocal(e.Location);
            lblInfo.Text = $"X: {point.X}\nY:{point.Y}\nScale: {scale}";
        }

        //���������� �������� ����������
        private void tbN_Scroll(object sender, EventArgs e)
        {
            Draw();
        }

        //����������� ������ �� ����� �����
        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            var point = ToLocal(e.Location);
            center = point;
            Draw();
        }

        //��� ��������� ������� ����
        private void pbMain_SizeChanged(object sender, EventArgs e)
        {
            InitImage();
            Draw();
        }

        //��� ������������ ����������� ���������� �������, ��� ��� �� �������� ������� �������� double

        /*
          //��� ��������� ������� ����
        private void pbMain_Resize(object sender, EventArgs e)
        {
            InitImage();
            Draw();
        }
         */
    }
}