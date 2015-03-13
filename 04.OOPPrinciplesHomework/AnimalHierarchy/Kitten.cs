namespace AnimalHierarchy
{
    using System;
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age, string breed)
        {
            this.Name = name;
            this.Age = age;
            this.Breed = breed;
        }

        public override string Name { get; protected set; }

        public override int Age { get; protected set; }

        public override char Sex
        {
            get { return 'F'; }
            protected set { this.Sex = 'F'; }
        }

        public override string Breed { get; protected set; }

        public override void MakeSound()
        {
            Console.WriteLine("Myaaau...");
        }
    }
}
