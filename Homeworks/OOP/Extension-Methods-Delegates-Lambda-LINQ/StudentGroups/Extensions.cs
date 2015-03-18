namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static List<Student> OrderGroups(this List<Student> list) //where T: Student
        {
            List<Student> ordered =
            list.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName).ToList();
            return ordered;
        }

        public static bool HaveTwoPoorMarks(this Student student)
        {
            int count = 0;
            foreach (var mark in student.Marks)
            {
                if (mark == 2) count++;
            }

            if (count == 2) return true;
            else return false;
        }

        public static string OrderByGroupName(this List<Student> list)
        {
            var groupedByGroupNumber = list
                             .OrderBy(x => x.GroupNumber)
                             .Select(x => new
                              {
                                  Name = string.Format("{0,-20}  ", x.FirstName + " " + x.LastName),
                                  Group = x.GroupNumber
                              });

            return string.Join(Environment.NewLine, groupedByGroupNumber);
        }
    }
}
