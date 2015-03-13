namespace SchoolClasses
{
    using System;
    class Student : Person
    {
        // for simplicity let's assume the class number will never begin a 0
        private ushort classNumber;

        public Student(string name, ushort classNumber)
        {
            this.Name = name;
            this.ClassNumber = classNumber;
        }

        public ushort ClassNumber
        {
            get { return this.classNumber; }
            private set 
            {
                if (value==0)
                {
                    throw new ArgumentException("Student class number must not be zero.");
                }
                this.classNumber = value; 
            }
        }
    }
}
