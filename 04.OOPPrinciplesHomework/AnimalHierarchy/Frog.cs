namespace AnimalHierarchy
{
    using System;
    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, char sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public override string Name { get; protected set; }

        public override int Age { get; protected set; }

        public override char Sex { get; protected set; }

        public override void MakeSound()
        {
            Console.WriteLine("Kwark kwark kwark...");
        }
    }
}
