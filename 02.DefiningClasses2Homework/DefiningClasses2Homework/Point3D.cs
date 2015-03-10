using System;
namespace DefiningClasses2Homework
{
    struct Point3D : IComparable<Point3D>
    {
        // structure fields
        private double X;
        private double Y;
        private double Z;

        private static readonly Point3D center = new Point3D(0, 0, 0);

        // constructor
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        //properties
        public double Abscissa
        {
            get
            {
                return this.X;
            }
        }

        public double Ordinate
        {
            get
            {
                return this.Y;
            }
        }

        public double Aplicate
        {
            get
            {
                return this.Z;
            }
        }

        public double DistanceToCenter
        {
            get
            {
                return PointOperations.GetDistance(this, Point3D.Center);
            }
        }

        public static Point3D Center
        {
            get
            {
                return center;
            }
        }

        // ToString() override
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
        }

        // operator overloads
        public static bool operator <(Point3D first, Point3D second)
        {
            if (first.DistanceToCenter<second.DistanceToCenter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Point3D first, Point3D second)
        {
            if (first.DistanceToCenter > second.DistanceToCenter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // implemenring the IComparable interface
        public int CompareTo(Point3D other)
        {
            return this.DistanceToCenter.CompareTo(other.DistanceToCenter);
        }
    }
}
