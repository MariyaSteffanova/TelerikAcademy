namespace StudentsAndWorkers
{
    using System.Text;

    public class Student : Human
    {
        private int grade;

        public Student()
        {
        }

        public Student(string firstName, string lastName, int grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Name : {0, -20}", this.FirstName + " " + this.LastName));
            sb.Append(string.Format(" | Grade : {0}", this.Grade));

            return sb.ToString();
        }
    }
}
