namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class Teacher : People
    {
        private List<Discipline> disciplines;

        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }
    }
}
