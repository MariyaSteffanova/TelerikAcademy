namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("JS UI & DOM", "Doncho Minkov", new List<string>() { "Pesho", "Gosho", "Stamat" }, "Ultimate");
            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "Data Structures and Algorithms", 
                "Nikolay Kostov",
                new List<string>() { "Thomas", "Ani", "Steve" }, 
                "Porto");

            offsiteCourse.Students.Add("John");
            offsiteCourse.Students.Add("Jimmy");

            var listCourses = new List<Course>() { localCourse, offsiteCourse };

            foreach (Course course in listCourses)
            {
                Console.WriteLine(course);
            }
        }
    }
}
