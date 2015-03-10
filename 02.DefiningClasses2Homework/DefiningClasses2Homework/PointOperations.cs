namespace DefiningClasses2Homework
{
    static class PointOperations
    {
        public static double GetDistance(Point3D first, Point3D second)
        {
            double result;
            result = System.Math.Sqrt(
                (first.Abscissa - second.Abscissa) * (first.Abscissa - second.Abscissa)
                + (first.Ordinate - second.Ordinate) * (first.Ordinate - second.Ordinate)
                + (first.Aplicate - second.Aplicate) * (first.Aplicate - second.Aplicate));
            return result;
        }
    }
}
