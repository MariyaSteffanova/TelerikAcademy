namespace SchoolClasses
{
    using System;

    public class Student : People 
    {
        private int classNumber;

        public int ClassNumber
        {
            get { return this.classNumber; }
            set { this.classNumber = value; }
        }        
    }
}
