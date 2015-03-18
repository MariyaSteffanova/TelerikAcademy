using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
   public class Test
    {
        public static void TestMatrix()
        {
            int size = 3;
            var randomElements = new Random();
            var min = 0;
            var max = 54;
            var first = new Matrix<int>(size, size);
            var second = new Matrix<int>(size, size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    first[row, col] = randomElements.Next(min, max);
                    second[row, col] = randomElements.Next(min, max);
                }
            }
            second[1, 1] = 0;
            Console.WriteLine("First MATRIX: \n{0}", first.ToString());
            Console.WriteLine("Second MATRIX \n{0}", second.ToString());
            Console.WriteLine("First matrix contains zero elements: {0}", first ? "true" : "false");
            Console.WriteLine("Second matrix contains zero elements: {0}", second ? "true" : "false");

            var result = first + second;
            Console.WriteLine(Environment.NewLine + "RESULT from ADDITION:" +
                Environment.NewLine + result.ToString());
            result = first - second;
            Console.WriteLine("RESULT from SUBSTRACTION (first - second):" + Environment.NewLine + result.ToString());
            result = second - first;
            Console.WriteLine("RESULT from SUBSTRACTION (second - first):" + Environment.NewLine + result.ToString());
            result = first * second;
            Console.WriteLine("RESULT from MULTIPLICATION:" + Environment.NewLine + result.ToString());

        }
    }
}
