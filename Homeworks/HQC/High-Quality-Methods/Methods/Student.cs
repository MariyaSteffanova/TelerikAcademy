namespace Methods
{
    using System;

    public class Student
    {
        private DateTime dateOfBirth;

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
            this.DateOfBirth = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                this.dateOfBirth = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.DateOfBirth;
            DateTime secondDate = other.DateOfBirth;
            return firstDate > secondDate;
        }
    }
}
