namespace Exam_Konspiration
{
    using System;
    using System.Collections.Generic;

    public class Konspiration
    {
        public static void Main()
        {
            int numLinesInput = int.Parse(Console.ReadLine());
            var declaredMethods = new List<string>();
            var invokedMethods = new List<List<string>>();

            for (int i = 0; i < numLinesInput; i++)
            {
                string currentLine = Console.ReadLine();

                declaredMethods = Extractor.GetDeclaredMethod(currentLine);

                if (Extractor.GetCurrentInvokedMethodsCount() >= 0)
                {
                    invokedMethods = Extractor.GetInvokedMethods(currentLine);
                }
            }

            PrintResult(declaredMethods, invokedMethods);
        }

        private static void PrintResult(List<string> declaredMethods, List<List<string>> invokedMethods)
        {
            for (int i = 0; i < declaredMethods.Count; i++)
            {
                Console.WriteLine("{0} -> {1}", declaredMethods[i], invokedMethods[i].Count == 0 ? "None" : invokedMethods[i].Count + " -> " + string.Join(", ", invokedMethods[i]));
            }
        }
    }
}
