//Problem 1. Student class
//Define a class Student, which contains data about a student – first, middle and last name, SSN, 
//permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, 
//universities and faculties.
//Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

//Problem 2. IClonable
//Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.

//Problem 3. IComparable
//Implement the IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).

namespace StudentClass
{
    using System;
    class StudentClass
    {
        static void Main()
        {

            Student stud1 = new Student("Pesho", "Goshov", "Stamatov", "0006969", 
                University.UniverityInNationalAndWorldEconomy, Faculty.EngineeringFaculty, Specialty.LandshaftEngineering);

            Student stud2 = new Student("Pesho", "Goshov", "Stamatov", "0006969", 
                University.UniverityInNationalAndWorldEconomy, Faculty.EngineeringFaculty, Specialty.LandshaftEngineering);

            // Equals override test
            Console.WriteLine("Equals override test:\n{0}\n",stud1.Equals(stud2));

            // ToString override test
            Console.WriteLine("ToString override test:\n{0}\n",stud1);

            // Clone test:
            Console.WriteLine("Clone test:\n{0}\n", stud1.Clone());

            // CompareTo rest:
            stud2 = new Student("Ceco", "Goshov", "Stamatov", "2226969",
                University.UniverityInNationalAndWorldEconomy, Faculty.EngineeringFaculty, Specialty.LandshaftEngineering);

            Console.WriteLine("CompareTo test:\n{0}\n", stud2.CompareTo(stud1));

            stud1 = new Student("Ceco", "Goshov", "Stamatov", "111969",
                University.UniverityInNationalAndWorldEconomy, Faculty.EngineeringFaculty, Specialty.LandshaftEngineering);

            Console.WriteLine(stud2.CompareTo(stud1));

        }
    }
}
