namespace ExtMethodsDelegatesLambdaLINQHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class RunTestsExtMethodsLINQ
    {
        static void Main()
        {
            Console.BufferHeight = 100;

            #region StringBuilder extension methods test
            Console.WriteLine("StringBuilder extension methods test:");
            StringBuilder sb = new StringBuilder("Pesho is very talented.");
            StringBuilder subBuilder = sb.Substring(1, 18);
            Console.WriteLine(subBuilder.ToString());
            #endregion

            #region IEnumerable extension methods test
            Console.WriteLine("\nIEnumerable extension methods test:");

            Console.WriteLine("Enumerable of type List<int>:");
            IEnumerable<int> integers = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7
            };
            foreach (int integer in integers)
            {
                Console.Write("{0} ", integer);
            }
            Console.WriteLine();
            Console.WriteLine("Sum: {0}", integers.Sum());
            Console.WriteLine("Min: {0}", integers.Min());
            Console.WriteLine("Max: {0}", integers.Max());
            Console.WriteLine("Average: {0}", integers.Average());
            Console.WriteLine("Product: {0}", integers.Product());
            #endregion

            #region Students class LINQ query -First before last- test
            Console.WriteLine("\nStudents class LINQ query -First before last- test:");
            var students = new List<Student>()
            {
                new Student("Vasil", "Dimitrov", 18),
                new Student("Pesho", "Smith", 32),
                new Student("Gosho", "Zmiqta", 29),
                new Student("Mitko", "Purata", 21),
                new Student("Mitko", "Ochite", 40),
                new Student("Gosho", "Zabavniq",23)
            };

            var filteredStudents = students.Where(x => x.FirstName.CompareTo(x.LastName) < 0).ToList();
            Console.WriteLine("Filtered students:");
            foreach (var stud in filteredStudents)
            {
                Console.WriteLine("{0} {1}", stud.FirstName, stud.LastName);
            }
            #endregion

            #region Students class LINQ query -Age range- test
            Console.WriteLine("\nStudents class LINQ query -Age range- test:");
            var moreFilteredStudents = students.Where(x => x.Age >= 18 && x.Age <= 24).ToList();
            foreach (var stud in moreFilteredStudents)
            {
                Console.WriteLine("{0} {1}, Age: {2}", stud.FirstName, stud.LastName, stud.Age);
            }
            #endregion

            #region OrderBy() and ThenBy() sorting test
            Console.WriteLine("\nOrderBy() and ThenBy() sorting test:");
            var orderedStudents = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
            foreach (var stud in orderedStudents)
            {
                Console.WriteLine("{0} {1}", stud.FirstName, stud.LastName);
            }
            #endregion

            #region LINQ sort test
            Console.WriteLine("\nLINQ sort test:");
            var moreOrderedStudents = from stud in students
                                      orderby stud.FirstName descending, stud.LastName descending
                                      select stud;
            foreach (var stud in moreOrderedStudents)
            {
                Console.WriteLine("{0} {1}", stud.FirstName, stud.LastName);
            }
            #endregion

            #region Divisible by 7 and 3 test lambda
            Console.WriteLine("\nDivisible by 7 and 3 test lambda:");
            int[] numbers = { 2, -4, 6, 8, 84, -21, 5 };
            var filteredNumbers = numbers.Where(x => x % 3 == 0 && x % 7 == 0).ToList();
            foreach (var num in filteredNumbers)
            {
                Console.WriteLine(num);
            }
            #endregion

            #region Divisible by 7 and 3 test LINQ
            Console.WriteLine("\nDivisible by 7 and 3 test LINQ:");
            var moreFilteredNumbers = from num in numbers
                                      where num % 3 == 0 && num % 7 == 0
                                      select num;
            foreach (var num in moreFilteredNumbers)
            {
                Console.WriteLine(num);
            }
            #endregion

            #region Student groups LINQ query test
            Console.WriteLine("\nStudent groups LINQ query test:");
            students = new List<Student>()
            {
                new Student("Vasil", "Dimitrov", 18, "25604", "0881111111", "vasko@abv.bg", new List<int>(){ 2, 5, 3 }, new Group(2, "Physics")),
                new Student("Pesho", "Smith", 32, "53606", "0881222111", "pesho@smith.com", new List<int>(){ 4, 5, 6 }, new Group(1, "Mathematics")),
                new Student("Gosho", "Zmiqta", 29, "31213", "02/881133311", "gosho@pesho.com", new List<int>(){ 5, 2, 3 }, new Group(5, "Mathematics")),
                new Student("Mitko", "Purata", 21, "25506", "02/846611111", "purata@magazina.pesho", new List<int>(){ 6, 6, 3 }, new Group(2, "Music")),
                new Student("Mitko", "Ochite", 40, "00800", "02/881287111", "ochite@me-bolqt.qk-s1m", new List<int>(){ 2, 5, 2 }, new Group(2, "Chemistry")),
                new Student("Gosho", "Zabavniq", 23, "51090", "0880297811", "goshoZZZZ@abv.bg", new List<int>(){ 2, 2, 6 }, new Group(7, "Mathematics"))
            };

            var groupOrderedStuds = from stud in students
                                    where stud.StudentGroup.GroupNumber == 2
                                    orderby stud.FirstName ascending, stud.LastName ascending
                                    select stud;
            foreach (var stud in groupOrderedStuds)
            {
                Console.WriteLine("{0} {1}, Group: {2}", stud.FirstName, stud.LastName, stud.StudentGroup.GroupNumber);
            }
            #endregion

            #region Student groups extension methods test
            Console.WriteLine("\nStudent groups extension methods test:");
            groupOrderedStuds = students.Where(x => x.StudentGroup.GroupNumber == 2).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            foreach (var stud in groupOrderedStuds)
            {
                Console.WriteLine("{0} {1}, Group: {2}", stud.FirstName, stud.LastName, stud.StudentGroup.GroupNumber);
            }
            #endregion

            #region Extract students by email LINQ test
            Console.WriteLine("\nExtract students by email LINQ test:");
            var emailFilteredStuds = from stud in students
                                     where stud.Email.EndsWith("abv.bg")
                                     orderby stud.FirstName ascending, stud.LastName ascending
                                     select stud;
            foreach (var stud in emailFilteredStuds)
            {
                Console.WriteLine("{0} {1}, Email: {2}", stud.FirstName, stud.LastName, stud.Email);
            }
            #endregion

            #region Extract students by telephone in Sofia LINQ test
            Console.WriteLine("\nExtract students by telephone in Sofia LINQ test:");
            var phoneFilteredStuds = from stud in students
                                     where stud.Telephone.StartsWith("02/")
                                     orderby stud.FirstName ascending, stud.LastName ascending
                                     select stud;
            foreach (var stud in phoneFilteredStuds)
            {
                Console.WriteLine("{0} {1}, Telephone: {2}", stud.FirstName, stud.LastName, stud.Telephone);
            }
            #endregion

            #region Extract students by marks LINQ test
            Console.WriteLine("\nExtract students by marks LINQ test:");
            var champions = from stud in students
                            where stud.Marks.Contains(6)
                            orderby stud.FirstName ascending, stud.LastName ascending
                            select new { FullName = stud.FirstName + " " + stud.LastName, Marks = stud.Marks };
            foreach (var champ in champions)
            {
                Console.WriteLine("{0}, Marks: {1}", champ.FullName, string.Join(",", champ.Marks));
            }
            #endregion

            #region Extract students with two marks LINQ test
            Console.WriteLine("\nExtract students with two marks LINQ test:");
            int mark = 2;
            int desiredOccurrences = 2;
            var antiChampions = from stud in students
                                where stud.Marks.Occurrences(mark) == desiredOccurrences
                                select stud;
            foreach (var antiChamp in antiChampions)
            {
                Console.WriteLine("{0} {1}, Marks: {2}", antiChamp.FirstName, antiChamp.LastName, string.Join(",", antiChamp.Marks));
            }
            #endregion

            #region Extract marks test
            Console.WriteLine("\nExtract marks test:");
            var filteredStuds = from stud in students
                                where stud.FN.EndsWith("06")
                                select stud;
            foreach (var stud in filteredStuds)
            {
                Console.WriteLine("{0} {1}, Marks: {2}, FN: {3}", stud.FirstName, stud.LastName, string.Join(",", stud.Marks), stud.FN);
            }
            #endregion

            #region Groups
            List<string> departments = new List<string>
            {
                "Mathematics"
            };

            Console.WriteLine("\nGroups test:");
            var geniusStudents = from stud in students
                                 join dep in departments on stud.StudentGroup.DepartmentName equals dep
                                 select stud;
            foreach (var stud in geniusStudents)
            {
                Console.WriteLine("{0} {1}, Group Dep: {2}", stud.FirstName, stud.LastName, stud.StudentGroup.DepartmentName);
            }
            #endregion

            #region Grouped by GroupName LINQ
            Console.WriteLine("\nGrouped by GroupName LINQ:");
            var groupedStudents = from stud in students
                                  group stud by stud.StudentGroup.DepartmentName;
            foreach (var studGroup in groupedStudents)
            {
                Console.WriteLine("Key: {0}", studGroup.Key);
                foreach (var student in studGroup)
                {
                    Console.WriteLine("\t{0} {1}", student.FirstName, student.LastName);
                }
            }
            #endregion

            #region Grouped by GroupName extensions
            Console.WriteLine("\nGrouped by GroupName extensions:");
            groupedStudents = students.GroupBy(stud => stud.StudentGroup.DepartmentName);
            foreach (var studGroup in groupedStudents)
            {
                Console.WriteLine("Key: {0}", studGroup.Key);
                foreach (var student in studGroup)
                {
                    Console.WriteLine("\t{0} {1}", student.FirstName, student.LastName);
                }
            }
            #endregion
        }
    }
}
