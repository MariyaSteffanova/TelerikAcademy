/*  Problem 3. First before last  |  Problem 4. Age range  |  Problem 5. Order students
--------------------------------------------------------------------------------------------------------------------------------------------------
  Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
  Use LINQ query operators.
  
  Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
  
  Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
  Rewrite the same with LINQ.
 -------------------------------------------------------------------------------------------------------------------------------*/
namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var gosho = new Student("Gosho", "Peshov", 18);
            var pesho = new Student("Pesho", "Goshov", 19);
            var angel = new Student("Angel", "Zlatkov", 26);
            var zlatko = new Student("Zlatko", "Angelov", 20);
            var allStudents = new List<Student>() { gosho, pesho, angel, zlatko };
            List<Student> students = allStudents.Where(x => x.FirstName[0].CompareTo(x.LastName[0]) < 0).ToList();

            Console.WriteLine("ALL STUDENTS:");
            Console.WriteLine(string.Join(Environment.NewLine, allStudents));

            Console.WriteLine(Environment.NewLine + "STUDENTS WHOSE FIRST NAME IS BEFORE ITS LAST NAME ALPHABETICALLY.");
            Console.WriteLine(string.Join(Environment.NewLine, students));

            students = allStudents.Where(x => x.Age > 18 && x.Age < 24).ToList();
            Console.WriteLine(Environment.NewLine + "STUDENTS WITH AGE BETWEEN 18 AND 24:");
            Console.WriteLine(string.Join(Environment.NewLine, students));

            var orderStudents = from student in allStudents
                                orderby student.FirstName descending, student.LastName descending
                                select student;
            Console.WriteLine(Environment.NewLine + "STUDENTS SORTED BY FIRST AND LAST NAME IN DESCENDING ORDER (with order by):");
            Console.WriteLine(string.Join(Environment.NewLine, orderStudents));

            var orderStudentsLambda = allStudents
                                    .OrderByDescending(x => x.FirstName)
                                    .ThenBy(x => x.LastName);
            Console.WriteLine(Environment.NewLine + "STUDENTS SORTED BY FIRST AND LAST NAME IN DESCENDING ORDER (with lambda expressions):");
            Console.WriteLine(string.Join(Environment.NewLine, orderStudentsLambda));
        }
    }
}
