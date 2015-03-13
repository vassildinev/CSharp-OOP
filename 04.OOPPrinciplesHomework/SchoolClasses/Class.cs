namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    class Class<T> where T : Student
    {
        private List<T> classmates;

        public Class(List<T> students)
        {
            this.Classmates = students;
        }

        public byte NumberOfStudents
        {
            get { return (byte)this.classmates.Count; }
        }

        public List<T> Classmates
        {
            get { return this.classmates; }
            set
            {
                if (value.Count==0)
                {
                    throw new ArgumentException("A class cannot contain zero students.");
                }
                else
                {
                    this.classmates = value;
                }
            }
        }
    }
}
