namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class Class : Comments
    {
        private List<Teacher> teachers;

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }
    }
}
