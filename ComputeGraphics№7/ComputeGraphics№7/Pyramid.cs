using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComputeGraphics_7
{
    public class Pyramid
    {
        // список с координатами вершин пирамиды
        public List<Vector3> Points { get; set; }

        // смещение
        private Vector3 Offset = new Vector3();

        // количество вершин основания пирамиды
        public int CountBasePoints { get; set; }

        // количество вершин пирамиды
        public int CountPoints { get; set; }

        // цвета граней
        public List<Color> ColorsFaces;

        // радиус окружности, которая лежит в основании пирамиды
        private int Radius = 50;
        private int Height = 100;

        // конструктор по умолчанию
        public Pyramid()
        {
            Points = new List<Vector3>();   //координаты вершин
            CountBasePoints = CountPoints = 0;  //количество вершин основания пирамиды
        }

        // конструктор
        public Pyramid(int _CountPoints, Vector3 center)
        {
            if (_CountPoints < 4)
                throw new Exception("class Pyramid :: Pyramid(int _CountPoints) :: _CountPoints < 4");

            CountPoints = _CountPoints;  // количество вершин пирамиды
            CountBasePoints = _CountPoints - 1;// количество вершин основания пирамиды

            //смещение по центу (располагаем по центру)
            Offset = center;

            Points = new List<Vector3>();// список с координатами вершин пирамиды
            SetPyramid();   //задаем координаты

            ColorsFaces = new List<Color>();// цвета граней
            SetColorsFaces();   //В зависимости от кол-ва граней записываем в список рандомные цвета
        }


        // задание координат пирамиды с помощью формулы из Википедии
        public void SetPyramid()
        {
            // очистим если есть
            if (Points.Count != 0)
                Points.Clear();

            // основание пирамиды
            for (int i = 0; i < CountBasePoints; i++)
            {
                Points.Add(new Vector3(
                    (int)(Radius * Math.Cos(i * 2 * Math.PI / CountBasePoints)), // X
                    0, // Y
                    (int)(Radius * Math.Sin(i * 2 * Math.PI / CountBasePoints)))); // Z
            }
            Points.Add(Points[0]); // для замыкани контура

            // вершина пирамиды
            Points.Add(new Vector3(0, -Height, 0));
        }


        //В зависимости от кол-ва граней записываем в список рандомные цвета
        public void SetColorsFaces()
        {
            //если в списке уже что-то есть, чистим
            if (ColorsFaces.Count > 0)
                ColorsFaces.Clear();

            //заносим рандомные цвета в список (по кол-ву вершин у основанию)
            for (int i = 0; i < CountBasePoints; i++)
            {
                ColorsFaces.Add(RandomColor());
            }
        }

        // отрисовка пирамиды в bitmap, цвет рёбер pen
        public void DrawPyramidBitmap(ref Bitmap bitmap, Pen pen)
        {
            long totalMemory = GC.GetTotalMemory(false);

            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            Vector3 camera = new Vector3(0, 0, Height * 4); // координаты камеры (наблюдателя)
            Pen fillPen = new Pen(Color.AliceBlue); // для заливки


            ///////// Отрисовка основания пирамиды //////////
            List<Vector3> basePoints = BasePyramid();   //вершины основания

            float vx1 = basePoints[0].X - basePoints[1].X;
            float vy1 = basePoints[0].Y - basePoints[1].Y;
            float vz1 = basePoints[0].Z - basePoints[1].Z;
            float vx2 = basePoints[1].X - basePoints[2].X;
            float vy2 = basePoints[1].Y - basePoints[2].Y;
            float vz2 = basePoints[1].Z - basePoints[2].Z;

            var VectorNormalBase = new Vector3(vy1 * vz2 - vz1 * vy2, vz1 * vx2 - vx1 * vz2, vx1 * vy2 - vy1 * vx2); ;
            PointF[] PolygonBase = new PointF[basePoints.Count];    //упорядоченная пара координат Х и Y с плавающей запятой
            for (int i = 0; i < basePoints.Count; i++)
            {
                PolygonBase[i].X = basePoints[i].X + Offset.X;
                PolygonBase[i].Y = basePoints[i].Y + Offset.Y;
            }

            if (Vector3.Dot(camera, VectorNormalBase) > 0)  //Dot Возвращает скалярное произведение двух векторов
            {
                g.FillPolygon(fillPen.Brush, PolygonBase);
                g.DrawPolygon(pen, PolygonBase);
            }
            /////////////// Конец //////////


            ///////////// Отрисовка граней пирамиды ///////////////
            Vector3[,] FacesVec = FacesPyramid(); // грани пирамиды
            List<Vector3> VectorNormalFaces = new (); // вектор нормали i-ой грани
            for (int i = 0; i < FacesVec.GetLength(0); i++)
            {
                
                vx1 = FacesVec[i, 0].X - FacesVec[i, 1].X;
                vy1 = FacesVec[i, 0].Y - FacesVec[i, 1].Y;
                vz1 = FacesVec[i, 0].Z - FacesVec[i, 1].Z;
                vx2 = FacesVec[i, 1].X - FacesVec[i, 2].X;
                vy2 = FacesVec[i, 1].Y - FacesVec[i, 2].Y;
                vz2 = FacesVec[i, 1].Z - FacesVec[i, 2].Z;

                VectorNormalFaces.Add(new Vector3(vy1 * vz2 - vz1 * vy2, vz1 * vx2 - vx1 * vz2, vx1 * vy2 - vy1 * vx2));
                
            }

            bool[] alpha = new bool[FacesVec.GetLength(0)];
            for (int i = 0; i < alpha.Length; i++)
            {

                alpha[i] = Vector3.Dot(camera, VectorNormalFaces[i]) < 0;
            }
            
            PointF[] PointsF = new PointF[3]; // полигон для отрисовки
            for (int i = 0; i < FacesVec.GetLength(0); i++)
            {
                if (alpha[i])
                {
                    PointsF[0] = new PointF(FacesVec[i, 0].X + Offset.X, FacesVec[i, 0].Y + Offset.Y);
                    PointsF[1] = new PointF(FacesVec[i, 1].X + Offset.X, FacesVec[i, 1].Y + Offset.Y);
                    PointsF[2] = new PointF(FacesVec[i, 2].X + Offset.X, FacesVec[i, 2].Y + Offset.Y);

                    fillPen.Color = ColorsFaces[i];
                    g.FillPolygon(fillPen.Brush, PointsF);  //заполняем цветом
                    g.DrawPolygon(pen, PointsF);    //рисуем
                }
            }
            ///////////// Конец ///////////////

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        //рандомим цвет
        public Color RandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next() % 255, rand.Next() % 255, rand.Next() % 255);
        }


        //список с кол-вом вершин у основания пирамиды
        public List<Vector3> BasePyramid()
        {
            List<Vector3> basePoints = new();

            //заполняем
            for (int i = 0; i < CountBasePoints; i++)
            {
                basePoints.Add(Points[i]);
            }

            return basePoints;
        }

        //грани пирамиды
        public Vector3[,] FacesPyramid()
        {
            Vector3[,] result = new Vector3[CountBasePoints, 3];

            for (int i = 0; i < CountBasePoints - 1; i++)
            {
                result[i, 0] = new Vector3(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z);
                result[i, 1] = new Vector3(Points[i].X, Points[i].Y, Points[i].Z);
                result[i, 2] = new Vector3(Points[i + 1].X, Points[i + 1].Y, Points[i + 1].Z);
            }

            result[CountBasePoints - 1, 0] = new Vector3(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z);
            result[CountBasePoints - 1, 1] = new Vector3(Points[CountBasePoints - 1].X, Points[CountBasePoints - 1].Y, Points[CountBasePoints - 1].Z);
            result[CountBasePoints - 1, 2] = new Vector3(Points[0].X, Points[0].Y, Points[0].Z);

            return result;

        }

        //вращение по х
        public void RotateX(double Angel)
        {
            double radians = Angel * Math.PI / 180.0;
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            for (int i = 0; i < Points.Count; i++)
            {
                double newX = Points[i].X;
                double newY = Points[i].Y * cos + Points[i].Z * (-sin);
                double newZ = Points[i].Y * sin + Points[i].Z * cos;

                Points[i] = new Vector3((int)newX, (int)newY, (int)newZ);
            }
        }

        //вращение по у
        public void RotateY(double Angel)
        {
            double radians = Angel * Math.PI / 180.0;
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            for (int i = 0; i < Points.Count; i++)
            {
                double newX = Points[i].X * cos + Points[i].Z * sin;
                double newY = Points[i].Y;
                double newZ = Points[i].X * (-sin) + Points[i].Z * cos;

                Points[i] = new Vector3((int)newX, (int)newY, (int)newZ);
            }
        }

        //вращение по z
        public void RotateZ(double Angel)
        {
            double radians = Angel * Math.PI / 180.0;
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            for (int i = 0; i < Points.Count; i++)
            {
                double newX = Points[i].X * cos + Points[i].Y * (-sin);
                double newY = Points[i].X * sin + Points[i].Y * cos;
                double newZ = Points[i].Z;

                Points[i] = new Vector3((int)newX, (int)newY, (int)newZ);
            }
        }


        // деструктор
        ~Pyramid() 
        {
            Points.Clear();
        }

    }
}
