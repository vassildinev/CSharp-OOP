namespace ExtMethodsDelegatesLambdaLINQHomework
{
    class Group
    {
        public string DepartmentName { get; private set; }
        public byte GroupNumber { get; private set; }

        public Group(byte groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }
    }
}
