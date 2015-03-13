namespace SchoolClasses
{
    using System;
    public abstract class Person
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (value.Length<2)
                {
                    throw new ArgumentException("Person name must be at least 2 characters long.");
                }
                this.name = value;
            }
        }
    }
}
