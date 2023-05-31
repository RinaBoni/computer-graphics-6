using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeGraphics_7
{
    public class Point3D
    {
        public int X {  get; set; }
        public int Y { get; set; }

        public int Z { get; set; }

        public Point3D()
        {
            X = Y = Z = 0;
        }

        public Point3D(int _X, int _Y, int _Z)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
        }

        public Point3D Clone()
        {
            return new Point3D(X, Y, Z);
        }

    }
}
