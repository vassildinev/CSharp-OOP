namespace Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double Height { get; protected set; }

        public override double Width { get; protected set; }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
