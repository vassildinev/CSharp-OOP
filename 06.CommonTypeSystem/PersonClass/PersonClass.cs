//Problem 4. Person class
//Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
//Override ToString() to display the information of a person and if age is not specified – to say so.
//Write a program to test this functionality.

namespace PersonClass
{
    using System;
    class PersonClass
    {
        static void Main()
        {
            Person pers = new Person("Pesho");
            Console.WriteLine("No age test:\n{0}\n", pers);

            pers = new Person("Gosho", 25);
            Console.WriteLine("Age test:\n{0}\n", pers);
        }
    }
}
