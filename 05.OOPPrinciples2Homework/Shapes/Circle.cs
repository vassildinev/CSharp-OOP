namespace Shapes
{
    using System;
    class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Width = radius;
            this.Height = this.Width;
        }

        public override double Height { get; protected set; }

        public override double Width { get; protected set; }

        public override double CalculateSurface()
        {
            return Math.PI * this.Width * this.Height / 4;
        }
    }
}
