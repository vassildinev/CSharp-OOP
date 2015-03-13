namespace StudentsAndWorkers
{
    using System;
    class Student : Human
    {
        private byte grade;
        public Student(string firstName, string lastName, byte grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public byte Grade
        {
            get { return this.grade; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Student grade must be different and lareger than zero.");
                }
                this.grade = value;
            }
        }
    }
}
