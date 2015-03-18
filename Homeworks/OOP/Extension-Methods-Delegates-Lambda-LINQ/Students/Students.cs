namespace Students
{
    using System;
    using System.Text;

    class Student
    {
        public Student(string fName, string lName, int age)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
        }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Name: {0,-18} | ", this.FirstName + " " + this.LastName));
            sb.Append(string.Format("Age: {0,-3} | ", this.Age));
            return sb.ToString();
        }
    }
}
