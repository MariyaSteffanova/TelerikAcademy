namespace SchoolClasses
{
    using System;

   public class Discipline : Comments
    {
        private string name;
        private int lectures;
        private int exercises;

        public int NumberOfExercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }
        
        public int NumberOfLectures
        {
            get { return this.lectures; }
            set { this.lectures = value; }
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }        
    }
}
