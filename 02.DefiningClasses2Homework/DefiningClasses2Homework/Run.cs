namespace DefiningClasses2Homework
{
    using System;
    using System.Collections.Generic;
    class Run
    {
        static void Main()
        {
            // GetDistance method test
            Point3D vectorBegin = new Point3D(1, 2.5, 0.8);
            Point3D vectorEnd = new Point3D(-0.1, 12.3, 4.502);
            Console.WriteLine("Distance between points {0} and {1}:", vectorEnd, vectorBegin);
            Console.WriteLine("{0:F3}\n", PointOperations.GetDistance(vectorBegin, vectorEnd));

            // PathStorage class test
            // read
            Console.WriteLine("Path in pathInput.txt contains the following points:");
            Path readFromFile = PathStorage.ReadPath();
            for (int i = 0; i < readFromFile.Length; i++)
            {
                Console.WriteLine(readFromFile[i]);
            }
            Console.WriteLine();

            // write
            Path writeToFile = new Path()
            {
                new Point3D(0.1,-5,2),
                new Point3D(2,4,6),
                new Point3D(-1, 2, 7),
                Point3D.Center
            };

            PathStorage.WritePath(writeToFile);

            Console.WriteLine("Write to file pathOutput finished.\n");

            //Generic List test
            GenericList<Point3D> listOfPoints = new GenericList<Point3D>();
            foreach (Point3D point in readFromFile)
            {
                listOfPoints.AppendBack(point);
                //listOfPoints.AppendFront(point);
                //listOfPoints.Insert(1, Point3D.Center);
            }

            // Generic List Max and Min test
            Console.WriteLine("Max and Min methods applied to the contents of pathInput.txt:");
            Console.WriteLine(listOfPoints.Max());
            Console.WriteLine(listOfPoints.Min());
            Console.WriteLine();

            // Matrix class test
            int height = 2;
            int width = 2;
            Matrix<int> first = new Matrix<int>(height, width);

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    first[row, col] = int.Parse(Console.ReadLine());
                }
            }

            Matrix<int> second = new Matrix<int>(width, height);

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    second[row, col] = int.Parse(Console.ReadLine());
                }
            }

            Matrix<int> result;

            Console.WriteLine("Multiplication:");
            result = first * second;
            result.PrintMatrix();
            Console.WriteLine();

            Console.WriteLine("Addition:");
            result = first + second;
            result.PrintMatrix();
            Console.WriteLine();

            Console.WriteLine("Subtraction:");
            result = first - second;
            result.PrintMatrix();
            Console.WriteLine();

            // attributes test
            Type type = typeof(Matrix<>);
            object[] allAttributes = type.GetCustomAttributes(typeof(VersionAttribute), false);
            foreach (VersionAttribute versionAttribute in allAttributes)
            {
                Console.WriteLine("The Matrix class is version {0}. ", versionAttribute.Name);
            }
        }
    }
}
