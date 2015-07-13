namespace MathFunctionsTesting
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class PerformanceTester
    {
        private const int ExecutionCount = 1000;

        private const float OperationParameterFloat = 1000f;
        private const double OperationParameterDouble = 1000;
        private const decimal OperationParameterDecimal = 1000m;

        public static void TestMathFunctions()
        {
            TestFunction(MathFunction.Square_Root);
            TestFunction(MathFunction.Natural_Logarithm);
            TestFunction(MathFunction.Sinus);
        }

        private static void TestFunction(MathFunction function)
        {
            var result = new StringBuilder();
            result.AppendFormat("Tests for [ {0} ]", function.ToString().Replace("_", " ")).AppendLine();

            var stopwatch = new Stopwatch();

            float resultFloat = OperationParameterFloat;
            stopwatch.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (function)
                {
                    case MathFunction.Square_Root:
                        resultFloat = (float)Math.Sqrt(OperationParameterFloat);
                        break;
                    case MathFunction.Natural_Logarithm:
                        resultFloat = (float)Math.Log(OperationParameterFloat);
                        break;
                    case MathFunction.Sinus:
                        resultFloat = (float)Math.Sin(OperationParameterFloat);
                        break;
                    default:
                        break;
                }
            }

            stopwatch.Stop();
            result.AppendFormat("{0,-15}:{1}", "[ Float ]", stopwatch.Elapsed).AppendLine();
            stopwatch.Reset();

            double resultDouble = OperationParameterDouble;
            stopwatch.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (function)
                {
                    case MathFunction.Square_Root:
                        resultDouble = Math.Sqrt(OperationParameterDouble);
                        break;
                    case MathFunction.Natural_Logarithm:
                        resultDouble = Math.Log(OperationParameterDouble);
                        break;
                    case MathFunction.Sinus:
                        resultDouble = Math.Sin(OperationParameterDouble);
                        break;
                    default:
                        break;
                }
            }

            stopwatch.Stop();
            result.AppendFormat("{0,-15}:{1}", "[ Double ]", stopwatch.Elapsed).AppendLine();
            stopwatch.Reset();

            decimal resultDecimal = OperationParameterDecimal;
            stopwatch.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (function)
                {
                    case MathFunction.Square_Root:
                        resultDecimal = (decimal)Math.Sqrt((double)OperationParameterDecimal);
                        break;
                    case MathFunction.Natural_Logarithm:
                        resultDecimal = (decimal)Math.Log((double)OperationParameterDecimal);
                        break;
                    case MathFunction.Sinus:
                        resultDecimal = (decimal)Math.Sin((double)OperationParameterDecimal);
                        break;
                    default:
                        break;
                }
            }

            stopwatch.Stop();
            result.AppendFormat("{0,-15}:{1}", "[ Decimal ]", stopwatch.Elapsed).AppendLine();
            stopwatch.Reset();

            Console.WriteLine(result.ToString());
        }
    }
}
