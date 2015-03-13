namespace StudentClass
{
    using System;

    public enum University
    {
        SofiaUniversity, TechnicalUniversity, UniverityInNationalAndWorldEconomy, UACEG
    }

    public enum Faculty
    {
        EngineeringFaculty, ArchitectureFaculty, AppliedSciencesFaculty
    }

    public enum Specialty
    {
        Architecture, ElectricalEngineering, LandshaftEngineering, MachineEngineering, Mathematics, Physics, SoftwareEngineering
    }

    public class Student : ICloneable, IComparable
    {
        public Student(string firstName, string middleName, string lastName, string ssn,
            University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;

            this.SSN = ssn;

            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;

            this.PermanentAddress = null;
            this.MobilePhone = null;
            this.Email = null;
        }

        public Student(string firstName, string middleName, string lastName, string ssn,
            University university, Faculty faculty, Specialty specialty, string permanentAddress, string mobilePhone, string email)
            : this(firstName, middleName, lastName, ssn,
            university, faculty, specialty)
        {
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public string SSN { get; private set; }

        public string PermanentAddress { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public University University { get; private set; }

        public Faculty Faculty { get; private set; }

        public Specialty Specialty { get; private set; }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            if (this.FirstName == student.FirstName
                && this.MiddleName == student.MiddleName
                && this.LastName == student.LastName
                && this.SSN == student.SSN
                && this.University == student.University
                && this.Faculty == student.Faculty
                && this.Specialty == student.Specialty
                && this.PermanentAddress == student.PermanentAddress)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + ", " + this.University + ", " + this.Faculty + ", " + this.Specialty;
        }

        public static bool operator ==(Student s, Student p)
        {
            if (s.Equals(p))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Student s, Student p)
        {
            if (s.Equals(p))
            {
                return false;
            }
            return true;
        }

        public object Clone()
        {
            Student result = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, 
                this.University, this.Faculty, this.Specialty);
            return result;
        }

        public int CompareTo(object obj)
        {
            var student = obj as Student;
            var result = this.FirstName.CompareTo(student.FirstName);
            if (result != 0) return result;

            result = this.SSN.CompareTo(student.SSN);
            return result;
        }
    }
}
