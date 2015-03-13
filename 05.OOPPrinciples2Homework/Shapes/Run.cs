//Problem 1. Shapes

//Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
//Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure 
//(heightwidth for rectangle and heightwidth/2 for triangle).
//Define class Circle and suitable constructor so that at initialization height 
//must be kept equal to width and implement the CalculateSurface() method.
//Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) 
//stored in an array.

namespace Shapes
{
    using System;
    class Run
    {
        static void Main()
        {
            var shapes = new Shape[]
            {
                new Circle(8),
                new Rectangle(5,4),
                new Triangle(7,14)
            };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Defined {0} has an area of: {1:F2}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
