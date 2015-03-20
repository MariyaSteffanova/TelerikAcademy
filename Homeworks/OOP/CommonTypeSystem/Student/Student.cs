namespace StudentClass
{
    using System;
    using System.Linq;
    using System.Text;
    /*Define a class Student, which contains data about a student – first, middle and last name, SSN, 
     permanent address, mobile phone e-mail, course, specialty, university, faculty. 
     Use an enumeration for the specialties, universities and faculties.*/
    public class Student : ICloneable, IComparable
    {
        public Student()
        {
        }

        #region Constructors
        public Student(string firstName, string middleName, string lastName,
                        ulong ssn, string address, string phone, string email)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.MobilePhone = phone;
            this.Email = email;
        }

        public Student(string firstName, string middleName, string lastName,
                        ulong ssn, string address, string phone, string email, int course,
                        UniversityName university, FacultyName faculty, SpecialtyName specialty)
                    : this(firstName, middleName, lastName, ssn, address, phone, email)
        {
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }
        #endregion

        #region Properties
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ulong SSN { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public int Course { get; set; }

        public SpecialtyName Specialty { get; set; }

        public UniversityName University { get; set; }

        public FacultyName Faculty { get; set; }
        #endregion
        public enum SpecialtyName
        {
            AICS, E, EE, EPE, EPSPT, ID, IM, HE, NAMT, RES, RM, SIT, SM, TEI, TET
        }

        public enum UniversityName
        {
            Technical_University_of_Sofia,
            Technical_University_of_Varna,
            Technical_University_of_Rousse
        }

        public enum FacultyName
        {
            Computer_Science_and_Information_Technology,
            Electronic_Engineering,
            Electronics_and_Automation,
            Marine_Sciences_and_Ecology,
            Mechanical_Engineering,
            Telecommunications,
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            if (this.FirstName == student.FirstName &&
                this.MiddleName == student.MiddleName &&
                this.LastName == student.LastName &&
                this.SSN == student.SSN &&
                this.Address == student.Address &&
                this.MobilePhone == student.MobilePhone &&
                this.Email == student.Email &&
                this.Course == student.Course &&
                this.Specialty == student.Specialty &&
                this.Faculty == student.Faculty &&
                this.University == student.University)
                return true;
            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var name = new StringBuilder();
            name.Append(this.FirstName);
            name.Append(" ");
            name.Append(this.MiddleName);
            name.Append(" ");
            name.Append(this.LastName);
            name.Append(" ");

            sb.Append(new string('_', 45));
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", this.GetType().Name.ToUpper(), name.ToString());
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "SSN", this.SSN);
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "ADDRESS", this.Address);
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "PHONE", this.MobilePhone);
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "E-MAIL", this.Email);
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "COURSE", this.Course);
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "UNIVERSITY", this.University.ToString().Replace("_", " "));
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "FACULTY", this.Faculty.ToString().Replace("_", " "));
            sb.AppendLine();
            sb.AppendFormat("{0,-10}: {1}", "SPECIALTY", this.Specialty);
            sb.AppendLine();
            sb.Append(new string('_', 45));
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            var sumSNN = this.SSN.ToString().Select(x => int.Parse(x.ToString())).ToArray().Sum();
            sumSNN += 2;
            var addition = (int)(this.SSN / (ulong)sumSNN);
            return base.GetHashCode() + addition;
        }

        public static bool operator ==(Student studentFirst, Student studentSecond)
        {
            return studentFirst.Equals(studentSecond);
        }

        public static bool operator !=(Student studentFirst, Student studentSecond)
        {
            return !(studentFirst.Equals(studentSecond));
        }

        public object Clone()
        {
            Student studentClone = new Student(
                this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.MobilePhone,
                this.Email, this.Course, this.University, this.Faculty, this.Specialty);

            return studentClone;
        }

        public int CompareTo(object obj)
        {          
            var student = obj as Student;
            if (this.FirstName.CompareTo(student.FirstName) <= 0)
            {
                return student.SSN.CompareTo(this.SSN);
            }

            return this.FirstName.CompareTo(student.FirstName);        
        }
    }
}
