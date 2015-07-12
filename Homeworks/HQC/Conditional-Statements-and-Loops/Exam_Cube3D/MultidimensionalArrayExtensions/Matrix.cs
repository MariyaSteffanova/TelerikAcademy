namespace Exam_Cube3D.MultidimensionalArrayExtensions
{
    using System;

    public static class Matrix
    {
        public static void Initialize<T>(this T[,] matrix, T value) 
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value;
                }
            }
        }

        /// <summary>
        /// Translate multidimensional int array to string one.
        /// </summary>
        /// <param name="matrix">The array for translation.</param>
        /// <param name="symbols">
        /// <para> The new values for the translated array.</para>
        /// <para> Every value of the int array are translated to symbols[value]</para>
        /// </param>
        public static string[,] Translate(this int[,] matrix, string[] symbols)           
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            string[,] transformedMatrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    for (int index = 0; index < symbols.Length; index++)
                    {
                        if (matrix[row, col] == index)
                        {
                            transformedMatrix[row, col] = symbols[index];
                        }
                    }
                }
            }

            return transformedMatrix;
        }

        public static void Print<T>(this T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void FillCol<T>(this T[,] matrix, int col, int start, int end, T value)
        {
            for (int row = start; row < end; row++)
            {
                matrix[row, col] = value;
            }
        }

        public static void FillRow<T>(this T[,] matrix, int row, int start, int end, T value)
        {
            for (int col = start; col < end; col++)
            {
                matrix[row, col] = value;
            }
        }

        public static void FillDiagonal<T>(this T[,] cube, int row, int start, int end, T value)
        {
            for (int col = start; col < end; col++)
            {
                cube[row, col] = value;
                row++;
            }
        }
    }
}
