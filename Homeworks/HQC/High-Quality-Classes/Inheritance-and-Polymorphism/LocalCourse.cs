namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab { get; set; }
        
        public override string ToString()
        {
            var courseLab = string.Format("Lab: {0}", this.Lab);
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine(courseLab);

            return result.ToString();
        }
    }
}
