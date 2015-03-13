namespace SchoolClasses
{
    using System.Collections.Generic;
    class Teacher : Person
    {
        private List<Discipline> proficientDisciplines;

        public Teacher(string name, List<Discipline> proficientDisciplines)
        {
            this.Name = name;
            this.ProficientDisciplines = proficientDisciplines;
        }

        public List<Discipline> ProficientDisciplines
        {
            get { return this.proficientDisciplines; }
            private set { this.proficientDisciplines = value; }
        }
    }
}
