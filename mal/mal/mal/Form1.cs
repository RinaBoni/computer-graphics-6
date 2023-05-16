using System.Security.Cryptography.X509Certificates;

namespace mal
{
    public partial class Form1 : Form
    {
        Bitmap image;//картинка на который будем рисовать

        class PointD
        {
            public double X;
            public double Y;
        }

        //для выода информации, которую рисуем, стобы рисоваиь изображение в центре экрана, cX и сY - координаты центра экрана
        /*double cX = 0;
        double cY = 0;*/
        PointD center = new PointD { X = 0, Y = 0 };
        double scale = 300;//для увеличения
        public Form1()
        {
            InitializeComponent();
            InitImage();
            Draw();

            //увеличение или уменьшение с помощью колесика мышки
            pbMain.MouseWheel += PbMain_MouseWheel;
        }

        private void PbMain_MouseWheel(object? sender, MouseEventArgs e)
        {
            scale *= e.Delta > 0 ? 1.5 : 1.0 / 1.5;
            Draw();
        }

        //инициализация битмапа
        void InitImage()
        {
            image = new Bitmap(
                pbMain.Width,
                pbMain.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb//чтобы было понятно откуда берутся значения
            );
            pbMain.Image = image;
        }

        //при изменении размнра окна
        private void pbMain_Resize(object sender, EventArgs e)
        {
            InitImage();
            Draw();
        }

        //для показа текущих координат
        //на входе точка в координатах пикчербокса, переводим в наши координаты (координаты класса)
        PointD ToLocal(Point point)
        {
            return ToLocal(point.X, point.Y);
        }

        PointD ToLocal(int x, int y)
        {
            return new PointD
            {
                X = (double)(x - (double)image.Width / 2) / scale + center.X,
                Y = -(double)(y - (double)image.Height / 2) / scale + center.Y,
            };
        }

        //отрисоввка множества мандельброта
        void Draw()
        {
            //обращаемся на прямую к панять обходя сборщик мусора
            //возвращает заблокированную память
            var data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),//блокируем полностью изображение
                 System.Drawing.Imaging.ImageLockMode.ReadWrite,//с какими целями блокируем 
                 System.Drawing.Imaging.PixelFormat.Format32bppArgb//указываем формат блокировоного изображения
                );

            //ссылка на область памяти Skan0 адресс первого байта изображения
            IntPtr ptr = data.Scan0;
            //тк мы берем байты к копируем их в массив, который будет управляться сборщиком мусора, узнаем какого размера нужно создать изображение
            int count = Math.Abs(data.Stride) * image.Height;//Stride - количество байт в одной строке 
            //создаем массив (количество байт) под нашу память 
            byte[] rgb = new byte[count];

            //копируем значение rgb в массив (откуда, куда, начало, конец)
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgb, 0, count);

            //для определения пренадлежит ли точка область
            int n = tbN.Value;  //tbN ограничение дальности расчета

            //проходимся по всем байтам изображения и что-то сделать(заполнение цветом)
            for (var y = 0; y < image.Height; ++y)
            {
                for (var x = 0; x < image.Width; ++x)
                {
                    //вычисляем адрес цвета(??)(тк он в массиве rgb) зная координаты х и у
                    int p = (y * image.Width + x) * 4;//у - адресс строки, каждая строка имеет длину image.widht, x - смещение данной строки, на один пиксель приходится 4 байта

                    //х0, y0 - точка от которой мы начинаем расчет/на которую навелись 
                    var xy0 = ToLocal(x, y);
                    //первые начальные точки(тк итеративная форма, должны запоминать с какой точки начали расчет)  
                    var xn = xy0.X; var yn = xy0.Y;
                    double xn_1, yn_1;
                    bool ok = true; //при расчете все пошло хорошо

                    //насколько блмзко мы расчитали пренадлежность пикеля к области, если i максимапльнт близка к n то ставим цвет близкий к ораньжевому, если бляже к 0 то цвет близкий к синему
                    //расчет множества
                    int i;
                    for (i = 0; i < n; i++)
                    {
                        //итеративные формулы
                        xn_1 = xn * xn - yn * yn + xy0.X;
                        yn_1 = 2 * xn * yn + xy0.Y;
                        //если точка не пренадлежит множеству, выходим из цикла
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
                        //каждое значение цвета имеет свое смещение, последний отвечает за альфа канал - прозрачность
                        rgb[p] = 179;//синий
                        rgb[p + 1] = 107;//зеленый
                        rgb[p + 2] = 0;//красный  
                        rgb[p + 3] = 255; //альфа
                    }
                    else
                    {
                        //коэфициент близости к синему
                        double k = 1 - (double)i / n;

                        //каждое значение цвета имеет свое смещение, последний отвечает за альфа канал - прозрачность
                        rgb[p] = (byte)((1 - k) * 76 + k * 179);//синий
                        rgb[p + 1] = (byte)((1 - k) * 148 + k * 107);//зеленый
                        rgb[p + 2] = (byte)((1 - k) * 255 + k * 0);//красный  
                        rgb[p + 3] = 255; //альфа
                    }


                }
            }
            //заносим данные обртно в поинтер (в битмат)
            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, ptr, count);
            //разблокируем область память (изоюражение)
            image.UnlockBits(data);
            //говорим пикчербоксу обновиться
            pbMain.Invalidate();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //при движении мыши в пикчербоксе выводит координаты мыши
        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            var point = ToLocal(e.Location);
            lblInfo.Text = $"X: {point.X}\nY:{point.Y}";
        }

        //увеличение точности вычислений
        private void tbN_Scroll(object sender, EventArgs e)
        {
            Draw();
        }

        //перемещение центра на место клика
        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            var point = ToLocal(e.Location);
            center = point;
            Draw();
        }
    }
}