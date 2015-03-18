using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix<T> where T : struct, IComparable
    {

        private int rows;
        private int cols;
        private T[,] genericMatrix;
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.genericMatrix = new T[this.rows, this.cols];
        }

        public Matrix(T[,] predefinedMatrix) //creates a matrix, consisting of predefined values, passed as a T[,]
        {
            this.genericMatrix = predefinedMatrix;
            this.rows = genericMatrix.GetLength(0);
            this.cols = genericMatrix.GetLength(1);
        }

        public T this[int indexOfRows, int indexOfCols]
        {
            get
            {
                if (indexOfRows > this.rows - 1 || indexOfRows < 0)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", indexOfRows));
                }

                if (indexOfCols > this.cols - 1 || indexOfCols < 0)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", indexOfCols));
                }
                T result = this.genericMatrix[indexOfRows, indexOfCols];
                return result;
            }

            set { this.genericMatrix[indexOfRows, indexOfCols] = value; }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.rows != secondMatrix.rows || firstMatrix.cols != secondMatrix.cols)
                throw new ArgumentException("The matrices should be of the same size");
            Matrix<T> result = new Matrix<T>(firstMatrix.rows, firstMatrix.cols);
            for (int r = 0; r < firstMatrix.rows; r++)
            {
                for (int c = 0; c < firstMatrix.cols; c++)
                {
                    result[r, c] = (dynamic)firstMatrix[r, c] + secondMatrix[r, c];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.rows != secondMatrix.rows || firstMatrix.cols != secondMatrix.cols)
                throw new ArgumentException("The matrices should be of the same size");
            Matrix<T> result = new Matrix<T>(firstMatrix.rows, firstMatrix.cols);
            for (int r = 0; r < firstMatrix.rows; r++)
            {
                for (int c = 0; c < firstMatrix.cols; c++)
                {
                    result[r, c] = (dynamic)firstMatrix[r, c] - secondMatrix[r, c];
                }
            }
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.cols != b.rows)
            {
                throw new ArgumentException("The matrices cannot be multiplied");
            }
            Matrix<T> resultMatrix = new Matrix<T>(a.rows, b.cols);
            T result = (dynamic)0;
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < b.cols; j++)
                {
                    for (int k = 0; k < a.cols; k++)
                    {
                        result += (dynamic)a[i, k] * b[k, j];
                    }
                    resultMatrix[i, j] = result;
                    result = (dynamic)0;
                }
            }
            return resultMatrix;
        }
        public static bool operator true(Matrix<T> matrix)
        {
            bool zeroElements = false;

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if (matrix[i, j] == (dynamic)0)
                    {
                        zeroElements = true;
                    }
                }
            }

            return zeroElements;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool zeroElements = true;

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if (matrix[i, j] != (dynamic)0)
                    {
                        zeroElements = false;
                    }
                }
            }

            return zeroElements;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    sb.Append(this.genericMatrix[row, col] + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
