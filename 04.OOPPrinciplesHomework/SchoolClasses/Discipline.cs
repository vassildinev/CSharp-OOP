namespace SchoolClasses
{
    using System;
    class Discipline
    {
        private string name;
        private byte lecturesCount;
        private byte exercisesCount;

        public Discipline(string name, byte lecturesCount, byte exercisesCount)
        {
            this.Name = name;
            this.LecturesCount = lecturesCount;
            this.ExercisesCount = exercisesCount;
        }

        public string Name 
        {
            get { return this.name; }
            private set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Discipline name must be at least 3 chacters long.");
                }
                this.name = value;
            }
        }

        public byte LecturesCount
        {
            get { return this.lecturesCount; }
            private set { this.lecturesCount = value; }
        }

        public byte ExercisesCount
        {
            get { return this.exercisesCount; }
            private set { this.exercisesCount = value; }
        }

    }
}
