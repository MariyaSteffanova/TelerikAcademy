namespace AlgorithmsTesting
{
    using System;

    public class AlgorithmsTesting
    {
        public static void Main()
        {
            Tester.TestSort(Algorithm.Selection);
            Tester.TestSort(Algorithm.Insertion);
            // TODO: Tester.TestSort(Algorithm.Qiuck);
        }
    }
}
