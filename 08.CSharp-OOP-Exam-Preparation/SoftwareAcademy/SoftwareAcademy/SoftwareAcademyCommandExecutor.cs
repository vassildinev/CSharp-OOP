namespace SoftwareAcademy
{
    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public abstract class Course : ICourse
    {
        public string Name { get; set; }

        public ITeacher Teacher { get; set; }

        public abstract void AddTopic(string topic);
    }

    public class CourseFactory : ICourseFactory
    {

        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public class LocalCourse : Course, ICourse, ILocalCourse
    {
        private string name;
        private string lab;
        private IList<string> topics = new List<string>();

        public LocalCourse(string name, ITeacher teacher, string lab)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Lab = lab;
        }

        public new string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException();
                }
                this.lab = value;
            }
        }

        public IList<string> Topics
        {
            get { return this.topics; }
            set { this.topics = value; }
        }

        public override void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            if (this.Teacher == null)
            {
                return null;
            }
            else
            {
                if (this.Topics.Count != 0)
                {
                    return string.Format("{0}: Name={1}; Teacher={2}; Topics=[{3}]; Lab={4};", this.GetType().Name, this.Name, this.Teacher.Name, string.Join(",", this.Topics), this.Lab);
                }
                else
                {
                    return string.Format("{0}: Name={1}; Teacher={2}; Lab={3};", this.GetType().Name, this.Name, this.Teacher.Name, this.Lab);
                }
            }
        }

    }

    public class OffsiteCourse : Course, ICourse, IOffsiteCourse
    {
        private string name;
        private string town;
        private IList<string> topics = new List<string>();

        public OffsiteCourse(string name = null, ITeacher teacher = null, string town = null)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Town = town;
        }

        public IList<string> Topics
        {
            get { return this.topics; }
            set { this.Topics = value; }
        }

        public override void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public new string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException();
                }
                this.town = value;
            }
        }

        public override string ToString()
        {
            if (this.Teacher == null)
            {
                return null;
            }
            else
            {
                if (this.Topics.Count != 0)
                {
                    return string.Format("{0}: Name={1}; Teacher={2}; Topics=[{3}]; Town={4};", this.GetType().Name, this.Name, this.Teacher.Name, string.Join(",", this.Topics), this.Town);
                }
                else
                {
                    return string.Format("{0}: Name={1}; Teacher={2}; Town={3};", this.GetType().Name, this.Name, this.Teacher.Name, this.Town);
                }
            }
        }
    }

    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses = new List<ICourse>();

        public Teacher(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public IList<ICourse> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            if (this.Courses.Count != 0)
            {
                return string.Format("Teacher: Name={0}; Courses=[{1}]", this.Name, string.Join(",", this.Courses));
            }
            else
            {
                return string.Format("Teacher: Name={0};", this.Name);
            }
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        public static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        private static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }

                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
