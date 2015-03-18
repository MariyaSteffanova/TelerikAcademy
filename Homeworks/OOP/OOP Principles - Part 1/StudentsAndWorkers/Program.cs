namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var gosho = new Student("Gosho", "Peshov", 7);
            var pesho = new Student("Pesho", "Goshov", 6);
            var misho = new Student("Misho", "Mihailov", 12);
            var tisho = new Student("Tisho", "Toshkov", 11);
            var tosho = new Student("Tosho", "Georgiev", 10);
            var grisho = new Student("Grisho", "Peshov", 10);
            var sasho = new Student("Sasho", "Aleksandrov", 8);
            var stamat = new Student("Stamat", "Petrov", 12);
            var yanis = new Student("Qnis", "Kiryakov", 7);
            var kyncho = new Student("Kyncho", "Vranchev", 9);

            var listStudents = new List<Student>()
            { gosho, pesho, misho, tisho, tosho, grisho, sasho, stamat, yanis, kyncho };

            var stSortedByGrade = listStudents.OrderBy(x => x.Grade).ToList();

            var angel = new Worker("Angel", "Vylkov", 150, 4);
            var viktor = new Worker("Viktor", "Angelov", 200, 6);
            var boqn = new Worker("Boyan", "Zahariev", 250, 8);
            var georgy = new Worker("Georgy", "Boyanov", 100, 3);
            var dean = new Worker("Dean", "Hristov", 550, 8);
            var evgeni = new Worker("Evgeni", "Vylkov", 175, 5);
            var joro = new Worker("Joro", "Zaykov", 180, 6);
            var zareh = new Worker("Zareh", "Masorbyan", 330, 6);
            var ivan = new Worker("Ivan", "Petrov", 770, 8);
            var marin = new Worker("Marin", "Marinov", 440, 7);

            var listWorkers = new List<Worker>()
            { angel, viktor, boqn, georgy, dean, evgeni, joro, zareh, ivan, marin };

            var wSortedByMoneyPerHour = listWorkers.OrderByDescending(x => x.MoneyPerHour()).ToList();

            Console.WriteLine("WORKERS ORDERED BY MONEY PER HOUR IN DESCENDING ORDER:");
            Console.WriteLine(string.Join(Environment.NewLine, wSortedByMoneyPerHour));

            Console.WriteLine(Environment.NewLine + "STUDENTS ORDERED BY GRADE:");
            Console.WriteLine(string.Join(Environment.NewLine, stSortedByGrade));

            var listPeople = new List<Human>();
            listPeople = listStudents.Select(s => s as Human).ToList();
            foreach (var worker in listWorkers)
            {
                listPeople.Add(worker as Human);
            }

            var orderedByName = listPeople.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            Console.WriteLine(Environment.NewLine + "STUDENTS AND WORKERS OREDERED BY NAME:");
            Console.WriteLine(string.Join(Environment.NewLine, orderedByName));
        }
    }
}
