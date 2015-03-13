//Problem 2. Students and workers

//Define abstract class Human with first name and last name. Define new class Student which is derived from Human 
//and has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay 
//and method MoneyPerHour() that returns money earned by hour by the worker. 
//Define the proper constructors and properties for this hierarchy.
//Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
//Initialize a list of 10 workers and sort them by money per hour in descending order.
//Merge the lists and sort them by first name and last name.

namespace StudentsAndWorkers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class StudentsAndWorkers
    {
        static void Main()
        {
            Console.BufferHeight = 100;

            // ordered students
            var students = new List<Student>
            {
                new Student("Pesho", "Goshov", 3),
                new Student("Ivan", "Marinov", 5),
                new Student("Mitko", "Petrov", 2),
                new Student("Sasho", "Peshov", 4),
                new Student("Vankata", "NaSasheto", 6),
                new Student("Mitio", "Kalashnika", 4),
                new Student("Mitko", "Ochite", 3),
                new Student("Stamat", "Georgiev", 3),
                new Student("Dart", "Weider", 2),
                new Student("Luke", "Skywalker", 6),
                new Student("Bart", "Simpson", 5)
            };

            var orderedStudents = from stud in students
                                  orderby stud.Grade ascending,
                                          stud.FirstName ascending,
                                          stud.LastName ascending
                                  select stud;

            Console.WriteLine("Ordered students by grade:\n");
            foreach (Student stud in orderedStudents)
            {
                Console.WriteLine("{0} {1}, Grade: {2}", stud.FirstName, stud.LastName, stud.Grade);
            }


            // ordered workers
            var workers = new List<Worker>
            {
                new Worker("John", "Grisham", 300, 4),
                new Worker("Jack", "Daniels", 500, 6),
                new Worker("Alex", "Mouse", 200, 3),
                new Worker("Eustace", "Peshov", 400, 5),
                new Worker("Marry", "Smith", 600, 8),
                new Worker("Jim", "Kalashnikov", 400, 5),
                new Worker("Johnny", "Walker", 300, 1),
                new Worker("Theodor", "Gecata", 300, 2),
                new Worker("George", "Weider", 200, 2),
                new Worker("Bill", "Clinton", 600, 3),
                new Worker("Bob", "Dylan", 500, 2)
            };

            Console.WriteLine("\nOrdered workers by money per hour:\n");
            var orderedWorkers = from worker in workers
                                 orderby worker.MoneyPerHour() ascending,
                                         worker.FirstName ascending,
                                         worker.LastName ascending
                                 select worker;

            foreach (Worker wrk in orderedWorkers)
            {
                Console.WriteLine("{0} {1}, Money per hour: {2:F2}", wrk.FirstName, wrk.LastName, wrk.MoneyPerHour());
            }

            // merging the two lists
            var mergedList = new List<Human>();
            foreach (Student stud in students)
            {
                mergedList.Add(stud);
            }
            foreach (Worker wrk in workers)
            {
                mergedList.Add(wrk);
            }

            Console.WriteLine("\nOrdered merged list:\n");
            var orderedMergedList = from human in mergedList
                                    orderby human.FirstName ascending,
                                            human.LastName ascending
                                    select human;
            foreach (Human hmn in orderedMergedList)
            {
                Console.WriteLine("{0} {1}", hmn.FirstName, hmn.LastName);
            }
        }
    }
}
