namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name { get; set; }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            string courseType = this.GetType().Name;
            string courseName = string.Format("Name: {0}", this.Name);
            string courseTeacher = string.Format("Teacher: {0}", this.TeacherName);
            string courseStudents = string.Empty;

            if (this.Students.Count > 0)
            {
                courseStudents = "Students: " + this.GetStudentsAsString();
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine(courseType);
            result.AppendLine(courseTeacher);
            result.AppendLine(courseStudents);

            return result.ToString();
        }
    }
}
