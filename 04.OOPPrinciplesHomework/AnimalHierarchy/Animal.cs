namespace AnimalHierarchy
{
    using System.Collections.Generic;
    public abstract class Animal : ISound
    {
        public abstract string Name { get; protected set; }
        public abstract int Age { get; protected set; }
        public abstract char Sex { get; protected set; }

        public abstract void MakeSound();

        public static double AverageAge(IList<Animal> animals)
        {
            double average = 0;
            foreach (Animal animal in animals)
            {
                average += animal.Age;
            }
            return average / animals.Count;
        }
    }
}
