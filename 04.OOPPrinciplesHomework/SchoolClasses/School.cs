namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    class School<T>
        where T : Class<Student>
    {
        private List<T> schoolClasses;

        public School(List<T> schoolClasses)
        {
            this.SchoolClasses = schoolClasses;
        }

        public byte NumberOfClasses { get { return (byte)this.schoolClasses.Count; } }

        public List<T> SchoolClasses
        {
            get { return this.schoolClasses; }
            private set
            {
                this.schoolClasses = value;
            }
        }
    }
}
