namespace LongestString
{
    using System;
    using System.Linq;
    class RunTestLongestString
    {
        static void Main()
        {
            string[] someStrings = new string[]
            {
                "Pesho", "Goshko","Mariika", "Dragancho", "Mitaka", "Aristot", "Ivancho"
            };

            var sortedStrings = from str in someStrings
                                orderby str.Length ascending, str ascending
                                select str;
            foreach (var item in sortedStrings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
