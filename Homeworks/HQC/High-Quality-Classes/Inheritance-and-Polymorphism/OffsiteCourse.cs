namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            string courseTown = string.Format("Town: {0}", this.Town);

            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine(courseTown);

            return result.ToString();
        }
    }
}
