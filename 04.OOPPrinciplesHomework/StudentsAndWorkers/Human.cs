namespace StudentsAndWorkers
{
    using System;
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name must be at least 2 characters long. ");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("last name must be at least 2 characters long. ");
                }
                this.lastName = value;
            }
        }
    }
}
