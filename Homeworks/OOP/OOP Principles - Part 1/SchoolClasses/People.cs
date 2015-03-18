namespace SchoolClasses
{
    using System;

    public class People : Comments
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }        
    }
}
