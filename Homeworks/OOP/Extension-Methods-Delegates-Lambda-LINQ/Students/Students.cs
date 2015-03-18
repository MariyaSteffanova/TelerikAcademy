using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
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
            sb.Append(this.FirstName + " ");
            sb.Append(this.LastName);
            return sb.ToString();
        }
    }
}
