using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
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

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
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

        static void CompileAndRun(string csharpCode)
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

    public abstract class Course : ICourse //
    {
        private List<string> topics = new List<string>();

        public ITeacher Teacher { get;  set; }
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {

                    this.name = value;

            }
        }
        public Course(string courseName)
        {
            this.Name = courseName;
        }
        public Course(string courseName, ITeacher teacher) //
        {
            this.Name = courseName;
            this.Teacher = teacher; 
        }

        public void AddTopic(string topic)
        {
            if (topic != null)
            {
                topics.Add(topic);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append(": Name=");
            sb.Append(this.Name);
            if (this.Teacher!=null)
            {
                sb.Append("; Teacher=");
                sb.Append(this.Teacher.Name);
            }
            if (topics.Count > 0)
            {
                sb.Append("; Topics=[");
                foreach (var item in topics)
                {
                    sb.Append(item);
                    sb.Append(", ");
                }
                sb.Length--;
                sb.Length--;
                sb.Append("]");
            }
            return sb.ToString();
        }

    }

    public class LocalCourse : Course, ILocalCourse //
    {
        private string lab ;
        public string Lab
        {
            get
            {
               return this.lab;
            }
            set
            {
                if (value != null)
                {
                    this.lab = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public LocalCourse(string courseName,ITeacher teacher ,string courseLab)
            :base(courseName,teacher)
        {
            this.Lab = courseLab;
        }

        public override string ToString()
        {
            return (base.ToString()+"; Lab="+this.Lab);
        }
       

        
    }

    public class OffsiteCourse : Course, IOffsiteCourse     //
    {
        public string town;
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value != null)
                {
                    this.town = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public OffsiteCourse(string courseName, ITeacher teacher, string courseTown)
        :base(courseName,teacher)
        {
            this.Town = courseTown;
        }

        public override string ToString()
        {
            return (base.ToString() + "; Town=" + this.Town);
        }
       
    }

    public class Teacher : ITeacher                         //
    {
        private List<ICourse> courses = new List<ICourse>();// 
        private string name;
        public string Name
        {
            get
            {
               return this.name;
            }
            set
            {
                if (value!=null)
                {
                    this.name = value;
                }
                else
	            {
                    throw new ArgumentNullException();
	            }
            }
        }
        //public Teacher()
        //{
        //}

        public Teacher(string teacherName)
        {
            this.Name = teacherName;
        }

        public void AddCourse(ICourse course)
        {
            if (course!=null)
            {
                courses.Add(course);
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Teacher: Name=");
            sb.Append(this.Name);
            if (courses.Count>0)
            {
                sb.Append("; Courses=[");
                foreach (var item in courses)
                {
                    sb.Append(item.Name);
                    sb.Append(", ");
                }
                sb.Length--;
                sb.Length--;
                sb.Append("]");
            }
            return sb.ToString();
        }
    }
}
