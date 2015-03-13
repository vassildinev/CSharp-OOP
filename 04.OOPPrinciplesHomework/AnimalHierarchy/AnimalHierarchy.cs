////ProbKUlem 3. Animal hierarchy

//Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
//Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
//Kittens and tomcats are cats. All animals are described by age, name and sex. 
//Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
//Create arrays of different kinds of animals and calculate the average age of each kind of animal 
//using a static method (you may use LINQ).


namespace AnimalHierarchy
{
    using System;
    class AnimalHierarchy
    {
        static void Main()
        {
            var tomcats = new Tomcat[]
            {
                new Tomcat("Pesho", 10, "Precious"),
                new Tomcat("Gosho", 18, "Sucker"),
                new Tomcat("Stamat", 21, "The Great"),
                new Tomcat("Pesho", 10, "Precious")
            };
            Console.WriteLine("Tomcats average age: {0}\n", Animal.AverageAge(tomcats));

            var frogs = new Frog[]
            {
                new Frog("Pesho", 13, 'M'),
                new Frog("Gosho", 11,'M'),
                new Frog("Stamat", 51,'M'),
                new Frog("Pesho", 32,'M')
            };
            Console.WriteLine("Frogs average age: {0}\n", Animal.AverageAge(frogs));

            var dogs = new Dog[]
            {
                new Dog("Pesho", 9, 'M'),
                new Dog("Gosho", 2,'M'),
                new Dog("Stamat", 1,'M'),
                new Dog("Pesho", 15,'M')
            };
            Console.WriteLine("Dogs average age: {0}\n", Animal.AverageAge(dogs));

            var kittens = new Kitten[]
            {
                new Kitten("Pesho", 7, "Precious"),
                new Kitten("Gosho", 11, "Sucker"),
                new Kitten("Stamat", 19, "The Great"),
                new Kitten("Pesho", 2, "Precious")
            };
            Console.WriteLine("Kittens average age: {0}\n", Animal.AverageAge(kittens));
        }
    }
}
