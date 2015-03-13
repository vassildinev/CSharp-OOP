namespace AnimalHierarchy
{
    using System;
    class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age, string breed)
        {
            this.Name = name;
            this.Age = age;
            this.Breed = breed;
        }

        public override string Name { get; protected set; }

        public override int Age { get; protected set; }

        public override char Sex
        {
            get { return 'M'; }
            protected set { this.Sex = 'M'; }
        }

        public override string Breed { get; protected set; }

        public override void MakeSound()
        {
            Console.WriteLine("Myau myau myau...");
        }
    }
}
