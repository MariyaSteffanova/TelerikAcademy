using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class Test
    {
        private static GenericList<int> list = new GenericList<int>();
        public static void CreateGenericList()
        {

            list.Add(5);
            list.Add(6);
            list.Add(5);
            list.Add(9);
            list.Add(4);
            list.Add(6);
            list.Add(2);
            list.Add(9);
            list.Add(4);
        }
        public static void TestGenericList()
        {
            Console.WriteLine("TESTING GENERIC LIST CLASS" + Environment.NewLine);
            Console.WriteLine("testList = new GenericList<int>();" + Environment.NewLine + "VALUES:");
            list.Print();
            Console.WriteLine("testList.Count = {0}", list.Count);

            Console.Write(Environment.NewLine + "testList[3] = ");
            var el = list.GetElement(3);
            Console.WriteLine(el);

            Console.WriteLine(Environment.NewLine + "REMOVE testList[3]" + Environment.NewLine + "VALUES:");
            list.Remove(3);
            list.Print();
            Console.WriteLine("testList.Count = {0}", list.Count);

            el = list.GetElement(5);
            Console.WriteLine(Environment.NewLine + "GET ELEMENT BY INDEX");
            Console.WriteLine("testList[5] = {0}", el);

            Console.WriteLine(Environment.NewLine + "INSERT 3 at INDEX 4: ");
            list.Insert(3, 4);
            Console.WriteLine(list.ToString());
            Console.WriteLine("testList.Count = {0}" + Environment.NewLine, list.Count);

            int index = list.IndexOf(4);
            Console.WriteLine("FIRST INDEX of 4 is: {0}", index);
            index = list.LastIndexOf(4);
            Console.WriteLine("LAST INDEX of 4 is: {0}", index);
            index = list.IndexOf(1);
            Console.WriteLine("FIRST INDEX of 1 is: {0}", index);


            var minValue = GenericList<int>.Min<int>(list.GetElement(3), list.GetElement(6));
            Console.WriteLine(Environment.NewLine + "The MIN value between testList[3] and testList[6] is: {0}", minValue);

            var maxValue = GenericList<int>.Max<int>(list.GetElement(3), list.GetElement(6));
            Console.WriteLine("The MAX value between testList[3] and testList[6] is: {0}", maxValue);

            Console.WriteLine(Environment.NewLine + "CLEAR GENERIC LIST");
            list.Clear();
            Console.Write("VALUES: ");
            list.Print();
        }
    }
}
