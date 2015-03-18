namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        private string fName;
        private string lName;
        private string fnumber;
        private string phoneNumber;
        private string mail;
        private List<int> marks;
        private int groupNumber;

        public Student(string fName, string lName, string fnumber, string phoneNumber, string mail, List<int> marks, int groupNumber)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.FN = fnumber;
            this.Tel = phoneNumber;
            this.Email = mail;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }

        public List<int> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }

        public string Email
        {
            get { return this.mail; }
            set { this.mail = value; }
        }

        public string Tel
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public string FN
        {
            get { return this.fnumber; }
            set { this.fnumber = value; }
        }

        public string LastName
        {
            get { return this.lName; }
            set { this.lName = value; }
        }

        public string FirstName
        {
            get { return this.fName; }
            set { this.fName = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Name: {0,-18} | ", this.FirstName + " " + this.LastName));

            sb.Append(string.Format("E-Mail: {0, -15} | ", this.Email));
            // sb.Append(" Marks: " + string.Join(",", this.Marks));
            sb.Append(string.Format("Group: {0,-3} | ", this.GroupNumber));
            sb.Append(string.Format("Phone number: {0, -11}", this.Tel));
            return sb.ToString();
        }
    }
}
