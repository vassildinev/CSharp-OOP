namespace Shapes
{
    public abstract class Shape
    {
        public abstract double Height { get; protected set; }

        public abstract double Width { get; protected set; }

        public abstract double CalculateSurface();
    }
}
