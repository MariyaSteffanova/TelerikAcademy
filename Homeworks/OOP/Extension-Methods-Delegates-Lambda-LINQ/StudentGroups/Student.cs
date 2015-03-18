using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{
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
            get { return groupNumber; }
            set { groupNumber = value; }
        }
        
        public List<int> Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        
        public string Email
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Tel
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        
        public string FN
        {
            get { return fnumber; }
            set { fnumber = value; }
        }
        
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }

        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Name: {0,-18} | ", this.FirstName +  " " + this.LastName));
          
            sb.Append(string.Format("E-Mail: {0, -15} | ", this.Email));
           // sb.Append(" Marks: " + string.Join(",", this.Marks));
            sb.Append(string.Format("Group: {0,-3} | ", this.GroupNumber));
            sb.Append(string.Format("Phone number: {0, -11}", this.Tel));
            return sb.ToString();
        }
       
    }
}
