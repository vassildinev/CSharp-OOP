namespace PersonClass
{
    public class Person
    {
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.Name, this.Age == null ? (dynamic)"Not specified" : this.Age);
        }
    }
}
