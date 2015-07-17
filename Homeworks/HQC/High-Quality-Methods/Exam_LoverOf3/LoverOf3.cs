namespace Exam_LoverOf3
{
    using System;
    using System.Linq;

    public class LoverOf3
    {
        private static int rows = 0;
        private static int cols = 0;

        public static void Main()
        {
            ReadInputDimentions();

            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix);

            int moves = int.Parse(Console.ReadLine());

            int sum = 0;
            int row = rows - 1;
            int col = 0;

            for (int i = 0; i < moves; i++)
            {
                string line = Console.ReadLine();
                string direction = line.Substring(0, 2);
                int movesOnDirection = int.Parse(line.Substring(3));

                if (movesOnDirection > matrix.GetLength(0) || movesOnDirection > matrix.GetLength(1))
                {
                    movesOnDirection = 1;
                }

                sum += SumVisitedCellVelues(matrix, ref row, ref col, direction, movesOnDirection);
            }

            Console.WriteLine(sum);
        }

        private static void ReadInputDimentions()
        {
            int[] fieldDimentions = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();
            rows = fieldDimentions[0];
            cols = fieldDimentions[1];
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
            }
        }

        private static int SumVisitedCellVelues(int[,] matrix, ref int row, ref int col, string direction, int movesCount)
        {
            var sum = 0;
            for (int move = 0; move < movesCount - 1; move++)
            {
                switch (direction)
                {
                    case "RU": if (row < 1 || col >= cols - 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[--row, ++col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        }

                        break;
                    case "UR": if (row < 1 || col >= cols - 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[--row, ++col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        }

                        break;

                    case "RD": if (row >= rows - 1 || col >= cols - 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[++row, ++col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        }

                        break;
                    case "DR": if (row >= rows - 1 || col >= cols - 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[++row, ++col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        } 
                        
                        break;

                    case "LD": if (row >= rows - 1 || col < 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[++row, --col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        }

                        break;
                    case "DL": if (row >= rows - 1 || col < 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[++row, --col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        } 
                        
                        break;

                    case "LU": if (row < 1 || col < 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[--row, --col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        }

                        break;
                    case "UL": if (row < 1 || col < 1)
                        {
                            break;
                        }
                        else
                        {
                            sum += matrix[--row, --col];

                            if (InRange(row, col))
                            {
                                matrix[row, col] = 0;
                            }
                        } 
                        
                        break;
                    default:
                        break;
                }
            }

            return sum;
        }

        private static bool InRange(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

        private static void FillMatrix(int[,] matrix)
        {
            int maxRow = matrix.GetLength(0) - 1;

            for (int row = maxRow; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 3 * ((maxRow - row) + col);
                }
            }
        }
    }
}
