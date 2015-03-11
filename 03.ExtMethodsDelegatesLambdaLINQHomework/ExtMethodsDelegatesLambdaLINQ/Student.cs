namespace ExtMethodsDelegatesLambdaLINQHomework
{
    using System.Collections.Generic;
    
    class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public byte Age { get; private set; }
        public string FN { get; private set; }
        public string Telephone { get; private set; }
        public string Email { get; private set; }
        public List<int> Marks { get; set; }
        public Group StudentGroup { get; private set; }

        public Student(string fName, string lName, byte age)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
        }

        public Student(string fName, string lName, byte age, string fn, string tel, string email, List<int> marks, Group group)
            : this(fName, lName, age)
        {
            this.FN = fn;
            this.Telephone = tel;
            this.Email = email;
            this.Marks = marks;
            this.StudentGroup = group;
        }
    }
}
