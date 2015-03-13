namespace StudentsAndWorkers
{
    using System;
    class Worker : Human
    {
        private ushort weekSalary;
        private byte workHoursPerDay;

        public Worker(string firstName, string lastName, ushort weekSalary, byte workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public ushort WeekSalary
        {
            get { return this.weekSalary; }
            set { this.weekSalary = value; }
        }

        public byte WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set { this.workHoursPerDay = value; }
        }

        public double MoneyPerHour()
        {
            byte workdaysCount = 5;
            return (double)this.weekSalary / (this.workHoursPerDay * workdaysCount);
        }
    }
}
