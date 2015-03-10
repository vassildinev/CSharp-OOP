namespace DefiningClasses2Homework
{
    using System.IO;
    using System.Linq;
    // all points in the text file be in the format "X Y Z" on separate lines
    static class PathStorage
    {
        const string DEFAULT_READ_TEXT_FILE_LOCATION = @"..\..\Paths\pathInput.txt";
        const string DEFAULT_WRITE_TEXT_FILE_LOCATION = @"..\..\Paths\pathOutput.txt";

        // fields
        static StreamReader sr;
        static StreamWriter sw;

        // methods for read / write
        public static Path ReadPath(string inputLocation = DEFAULT_READ_TEXT_FILE_LOCATION)
        {
            if (!File.Exists(inputLocation))
            {
                throw new FileNotFoundException();
            }

            Path result = new Path();
            using(sr = new StreamReader(inputLocation))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    double[] coordinates = line.Split(' ').Select(double.Parse).ToArray();
                    Point3D currentPoint = new Point3D(coordinates[0], coordinates[1],coordinates[2]);
                    result.Add(currentPoint);

                    line = sr.ReadLine();
                }
                return result;
            }
        }

        public static void WritePath(Path pathToWrite, string outputLocation = DEFAULT_WRITE_TEXT_FILE_LOCATION)
        {
            using (sw = new StreamWriter(outputLocation))
            {
                for (int i = 0; i < pathToWrite.Length; i++)
                {
                    sw.WriteLine("{0} {1} {2}",
                        pathToWrite[i].Abscissa,
                        pathToWrite[i].Ordinate,
                        pathToWrite[i].Aplicate);
                }
            }
        }
    }
}
