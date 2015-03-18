/*--------------------------------------------------------------------------------------------------------------------------
  Tasks from 9 to 19 
 -------------------------------------------------------------------------------------------------------------------------*/

namespace StudentGroups
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var pesho = new Student("Pesho", "Goshov", "123408", "+346 889 10 25 92", "pesho@gmail.com",
                new List<int> { 2, 5, 6 }, 5);
            var tosho = new Student("Tosho", "Goshov", "123406", "+330 879 10 25 92", "tosho@abv.bg",
                new List<int> { 6, 6, 6 }, 2);
            var misho = new Student("Misho", "Vranchev", "432106", "+357 889 10 25 72", "misho@gmail.com",
                new List<int> { 5, 5, 6 }, 2);
            var sasho = new Student("Sasho", "Aleksandrov", "123415", "+328 889 11 23 92", "sasho@gmail.com",
                new List<int> { 4, 2, 2 }, 2);
            var grisho = new Student("Grisho", "Grishov", "123407", "+348 879 11 25 22", "grisho@abv.bg",
                new List<int> { 6, 6, 6 }, 2);
            var tisho = new Student("Tisho", "Toshkov", "933406", "+359 889 10 15 72", "tisho@gmail.com",
                new List<int> { 2, 2, 6 }, 2);
            var gosho = new Student("Gosho", "Peshov", "123414", "+359 899 10 25 92", "gosho@abv.bg",
               new List<int> { 4, 5, 4 }, 4);

            var allStudents = new List<Student>{
                          tosho, grisho , gosho, misho, sasho,  pesho,tisho};

            Console.WriteLine("ALL STUDENTS:");
            Console.WriteLine(string.Join(Environment.NewLine, allStudents));

            var studentsGroupTwo = allStudents.Where(x => x.GroupNumber == 2).ToList();
            Console.WriteLine(Environment.NewLine + "STUDENTS IN GROUP 2:");
            Console.WriteLine(string.Join(Environment.NewLine, studentsGroupTwo));

            var orderedStudentGroupTwo = studentsGroupTwo.OrderBy(x => x.FirstName).ToList();
            Console.WriteLine(Environment.NewLine + "STUDENTS IN GROUP 2 (ordered by First name) ");
            Console.WriteLine(string.Join(Environment.NewLine, orderedStudentGroupTwo));

            // Task 10
            Console.WriteLine(Environment.NewLine + "STUDENTS IN GROUP 2 ORDERED BY FIRST NAME (with extension method)");
            var ordered = allStudents.OrderGroups();
            Console.WriteLine(string.Join(Environment.NewLine, ordered));

            // Task 11
            Console.WriteLine(Environment.NewLine + "STUDENTS WITH E-MAILS IN ABV.BG:");
            var abvUsers = allStudents.Where(x => x.Email.Contains("abv.bg"));
            Console.WriteLine(string.Join(Environment.NewLine, abvUsers));

            // Task 12
            Console.WriteLine(Environment.NewLine + "STUDENTS WITH PHONE NUMBERS IN SOFIA, BULGARIA");
            var bgPhoneHolders = allStudents.Where(x => x.Tel.Substring(0, 4) == "+359")
                                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, bgPhoneHolders));

            // Task 13
            Console.WriteLine(Environment.NewLine + "STUDENTS WITH AT LEAST ONE EXCELLENT MARK: ");
            var ExcellentMarks = allStudents
                                    .Where(x => x.Marks.Contains(6))
                                    .Select(x => new { Name =string.Format("{0,-20}", x.FirstName + " " + x.LastName), 
                                                       Marks = string.Format("{0,-5}",string.Join(" ", x.Marks) )});
            Console.WriteLine(string.Join(Environment.NewLine, ExcellentMarks));
             
            // Task 14
            Console.WriteLine(Environment.NewLine + "STUDENTS WITH TWO POOR MARKS:");
            var PoorMarks = allStudents
                                .Where(x=> x.HaveTwoPoorMarks() == true)
                                .Select(x => new
                                {
                                    Name = string.Format("{0,-20}", x.FirstName + " " + x.LastName),
                                    Marks = string.Format("{0,-5}", string.Join(" ", x.Marks))
                                });
            Console.WriteLine(string.Join(Environment.NewLine, PoorMarks));
            // Task 15
            Console.WriteLine(Environment.NewLine + "STUDENTS ENROLLED IN 2006:");
            var class2006 = allStudents
                                .Where(x=> x.FN.Substring(4, 2) == "06")
                                 .Select(x => new
                                 {
                                     Name = string.Format("{0,-20}", x.FirstName + " " + x.LastName),
                                     Marks = string.Format("{0,-5}  ", string.Join(" ", x.Marks)),
                                     FN = x.FN
                                 });
            Console.WriteLine(string.Join(Environment.NewLine, class2006));

            // Task 17
            Console.WriteLine(Environment.NewLine+ "LONGEST STRING (LAST NAME) IS:");
            string[] longestString = allStudents                                        
                                        .Select(x=> x.LastName)                                          
                                        .ToArray();
            string longest = longestString.OrderBy(x=> x.Length).Last();
            Console.WriteLine(string.Join("",longest));

            // Task 18
            Console.WriteLine(Environment.NewLine + "STUDENTS GROUPED BY GROUP NUMBER:");
            var groupedByGroupNumber = allStudents
                                        .OrderBy(x=> x.GroupNumber)
                                         .Select(x => new
                                         {
                                             Name = string.Format("{0,-20}  ", x.FirstName + " " + x.LastName),
                                             Group = x.GroupNumber                                             
                                         });
            Console.WriteLine(string.Join(Environment.NewLine, groupedByGroupNumber));

            //Task 19
            Console.WriteLine(Environment.NewLine + "STUDENTS GROUPED BY GROUP NUMBER (using extension method):");
            var groupedByGroupNumber2 = allStudents.OrderByGroupName();
           
            Console.WriteLine( groupedByGroupNumber2);
        }
    }
}
