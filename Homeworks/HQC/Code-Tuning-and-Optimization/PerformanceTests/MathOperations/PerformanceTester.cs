namespace MathOperationsTesting
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public enum MathOperation
    {
        Addition,
        Subtraction,
        Incrementation,
        Multiplication,
        Division
    }

    public static class PerformanceTester
    {
        private const int ExecutionCount = 1000;

        private const int OperationParameterInt = 1;
        private const long OperationParameterLong = 1;
        private const float OperationParameterFloat = 1.0f;
        private const double OperationParameterDouble = 1.0;
        private const decimal OperationParameterDecimal = 1.0m;

        public static void TestMathOperstions()
        {
            TestOperation(MathOperation.Addition);
            TestOperation(MathOperation.Subtraction);
            TestOperation(MathOperation.Incrementation);
            TestOperation(MathOperation.Multiplication);
            TestOperation(MathOperation.Division);
        }

        public static void TestOperation(MathOperation operation)
        {
            var result = new StringBuilder();
            result.AppendFormat("Tests for: [ {0} ]", operation).AppendLine();
            var stop = new Stopwatch();
            int resultInt = OperationParameterInt;

            stop.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (operation)
                {
                    case MathOperation.Addition:
                        resultInt += OperationParameterInt;
                        break;
                    case MathOperation.Subtraction:
                        resultInt -= OperationParameterInt;
                        break;
                    case MathOperation.Incrementation:
                        resultInt++;
                        break;
                    case MathOperation.Multiplication:
                        resultInt *= OperationParameterInt;
                        break;
                    case MathOperation.Division:
                        resultInt /= OperationParameterInt;
                        break;
                    default:
                        break;
                }
            }

            stop.Stop();
            result.AppendFormat("{0,-15} : {1}", "[ Int ]", stop.Elapsed).AppendLine();
            stop.Reset();

            long resultLong = OperationParameterLong;
            stop.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (operation)
                {
                    case MathOperation.Addition:
                        resultLong += OperationParameterLong;
                        break;
                    case MathOperation.Subtraction:
                        resultLong -= OperationParameterLong;
                        break;
                    case MathOperation.Incrementation:
                        resultLong++;
                        break;
                    case MathOperation.Multiplication:
                        resultLong *= OperationParameterLong;
                        break;
                    case MathOperation.Division:
                        resultLong /= OperationParameterLong;
                        break;
                    default:
                        break;
                }
            }

            stop.Stop();
            result.AppendFormat("{0,-15} : {1}", "[ Long ]", stop.Elapsed).AppendLine();
            stop.Reset();

            float resultFloat = OperationParameterFloat;
            stop.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (operation)
                {
                    case MathOperation.Addition:
                        resultFloat += OperationParameterFloat;
                        break;
                    case MathOperation.Subtraction:
                        resultFloat -= OperationParameterFloat;
                        break;
                    case MathOperation.Incrementation:
                        resultFloat++;
                        break;
                    case MathOperation.Multiplication:
                        resultFloat *= OperationParameterFloat;
                        break;
                    case MathOperation.Division:
                        resultFloat /= OperationParameterFloat;
                        break;
                    default:
                        break;
                }
            }

            stop.Stop();
            result.AppendFormat("{0,-15} : {1}", "[ Float ]", stop.Elapsed).AppendLine();
            stop.Reset();

            double resultDouble = OperationParameterDouble;
            stop.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (operation)
                {
                    case MathOperation.Addition:
                        resultDouble += OperationParameterDouble;
                        break;
                    case MathOperation.Subtraction:
                        resultDouble -= OperationParameterDouble;
                        break;
                    case MathOperation.Incrementation:
                        resultDouble++;
                        break;
                    case MathOperation.Multiplication:
                        resultDouble *= OperationParameterDouble;
                        break;
                    case MathOperation.Division:
                        resultDouble /= OperationParameterDouble;
                        break;
                    default:
                        break;
                }
            }

            stop.Stop();
            result.AppendFormat("{0,-15} : {1}", "[ Double ]", stop.Elapsed).AppendLine();
            stop.Reset();

            decimal resultDecimal = OperationParameterDecimal;
            stop.Start();

            for (int i = 0; i < ExecutionCount; i++)
            {
                switch (operation)
                {
                    case MathOperation.Addition:
                        resultDecimal += OperationParameterDecimal;
                        break;
                    case MathOperation.Subtraction:
                        resultDecimal -= OperationParameterDecimal;
                        break;
                    case MathOperation.Incrementation:
                        resultDecimal++;
                        break;
                    case MathOperation.Multiplication:
                        resultDecimal *= OperationParameterDecimal;
                        break;
                    case MathOperation.Division:
                        resultDecimal /= OperationParameterDecimal;
                        break;
                    default:
                        break;
                }
            }

            stop.Stop();
            result.AppendFormat("{0,-15} : {1}", "[ Decimal ]", stop.Elapsed).AppendLine();
            stop.Reset();
            Console.WriteLine(result.ToString());
        }
    }
}
