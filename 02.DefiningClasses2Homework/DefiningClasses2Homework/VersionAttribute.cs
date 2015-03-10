namespace DefiningClasses2Homework
{
    using System;
    public class VersionAttribute : Attribute
    {
        
        public string Name { get; private set; }

        public VersionAttribute(string ver)
        {
            this.Name = ver;
        }
    }
}
