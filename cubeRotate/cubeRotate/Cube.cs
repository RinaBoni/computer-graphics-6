using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace cubeRotate
{
    internal class Cube
    {
        private int x;
        private int y;
        private int z;
        private int lenght;
        private List<Vector3> edges;
        public Cube(int x, int y, int z, int lenght) {

            this.x = x;
            this.y = y;
            this.z = z;
            setLenght(lenght);
            createEdges();
        }
        public Cube(Cube cube)
        {

            this.x = cube.x;
            this.y = cube.y;
            this.z = cube.z;
            setLenght(cube.lenght);
            this.edges = edges.ToList();
        }
        public Cube(List<Vector3> edges) {
            this.edges = edges.ToList();
        }
        // возращает значение вершины
        public Vector3 getPoint(int index)
        {
            if (index >= 0 && index < 8) 
            {
                return edges[index];
            }
            else
                throw(new IndexOutOfRangeException());
        }
        public void setLenght(int lenght)
        {
            if(lenght > 0) {
            this.lenght = lenght;
            createEdges();
            }
            else
                throw (new Exception("lenght shoud be more then 0!"));
        }
        
        public void setX(int x)
        {
            this.x = x;
            createEdges();
        }

        public void setY(int y)
        {
            this.y = y;
            createEdges();
        }

        public void setZ(int z)
        {
            this.z = z;
            createEdges();
        }
        // создаёт лист с координатами вершин
        private void createEdges()
        {
            edges = new List<Vector3>
            {
                new Vector3(x, y, z),
                new Vector3(x + lenght, y, z),
                new Vector3(x + lenght, y + lenght, z),
                new Vector3(x, y + lenght, z),
                new Vector3(x, y, z + lenght),
                new Vector3(x + lenght, y, z + lenght),
                new Vector3(x + lenght, y + lenght, z + lenght),
                new Vector3(x, y + lenght, z + lenght),
                
            };
        }
        // афинное преобразование куба для его вращения
        public void rotateCube(Bitmap bmp, ref Cube cube, double grad, double centerX, double centerY, double centerZ, int flagX, int flagY)
        {
            grad /= 180 / Math.PI;
            double x, y, z;
            double xc, yc;
            List<Vector3> edges = new List<Vector3>();
            for (int i = 0; i < 8; i++)
            {
                x = this.getPoint(i).X;
                y = this.getPoint(i).Y;
                z = this.getPoint(i).Z;
                xc = 0; yc = 0;
                if (flagX == 1)
                {
                    xc = x - centerX;
                    x = xc * Math.Cos(grad) + (z - centerZ) * Math.Sin(grad) + centerX;
                    z = -xc * Math.Sin(grad) + (z - centerZ) * Math.Cos(grad) + centerZ;
                }
                if (flagY == 1)
                {
                    yc = y - centerY;
                    y = yc * Math.Cos(grad) + (z - centerZ) * Math.Sin(grad) + centerY;
                    z = -yc * Math.Sin(grad) + (z - centerZ) * Math.Cos(grad) + centerZ;
                }

                edges.Add(new Vector3((float)x, (float)y, (float)z));
            }
            cube = new Cube(edges);
        }
        // размещение куба в bitmap
        public void placeCube(Bitmap bmp, Color color)
        {
            // ребро AB
            Logic.brezenhem(bmp, (int)this.getPoint(0).X, (int)this.getPoint(0).Y, (int)this.getPoint(1).X, (int)this.getPoint(1).Y, color);
            // ребро AD
            Logic.brezenhem(bmp, (int)this.getPoint(0).X, (int)this.getPoint(0).Y, (int)this.getPoint(3).X, (int)this.getPoint(3).Y, color);
            // ребро AA1
            Logic.brezenhem(bmp, (int)this.getPoint(0).X, (int)this.getPoint(0).Y, (int)this.getPoint(4).X, (int)this.getPoint(4).Y, color);
            // ребро BB1    
            Logic.brezenhem(bmp, (int)this.getPoint(1).X, (int)this.getPoint(1).Y, (int)this.getPoint(5).X, (int)this.getPoint(5).Y, color);
            // ребро CC1
            Logic.brezenhem(bmp, (int)this.getPoint(2).X, (int)this.getPoint(2).Y, (int)this.getPoint(6).X, (int)this.getPoint(6).Y, color);
            // ребро C1D1
            Logic.brezenhem(bmp, (int)this.getPoint(6).X, (int)this.getPoint(6).Y, (int)this.getPoint(7).X, (int)this.getPoint(7).Y, color);
            // ребро CD
            Logic.brezenhem(bmp, (int)this.getPoint(2).X, (int)this.getPoint(2).Y, (int)this.getPoint(3).X, (int)this.getPoint(3).Y, color);
            // ребро B1C1
            Logic.brezenhem(bmp, (int)this.getPoint(5).X, (int)this.getPoint(5).Y, (int)this.getPoint(6).X, (int)this.getPoint(6).Y, color);
            // ребро A1B1
            Logic.brezenhem(bmp, (int)this.getPoint(4).X, (int)this.getPoint(4).Y, (int)this.getPoint(5).X, (int)this.getPoint(5).Y, color);
            // ребро CB
            Logic.brezenhem(bmp, (int)this.getPoint(2).X, (int)this.getPoint(2).Y, (int)this.getPoint(1).X, (int)this.getPoint(1).Y, color);
            // ребро A1D1
            Logic.brezenhem(bmp, (int)this.getPoint(4).X, (int)this.getPoint(4).Y, (int)this.getPoint(7).X, (int)this.getPoint(7).Y, color);
            // ребро DD1
            Logic.brezenhem(bmp, (int)this.getPoint(3).X, (int)this.getPoint(3).Y, (int)this.getPoint(7).X, (int)this.getPoint(7).Y, color);
        }

      

    }
}
