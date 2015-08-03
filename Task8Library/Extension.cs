using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Library
{
    public static class Extension
    {
        public static IMatrix<T> Add<T>(this IMatrix<T> matrix, IMatrix<T> otherMatrix)
        {
            T[][] array = new T[matrix.Len][];
            if (otherMatrix == null || matrix.Len != otherMatrix.Len)
                throw new Exception("The matrix can't be summared");
            try
            {
                for (int i = 0; i < matrix.Len; i++)
                {
                    array[i] = new T[matrix.Len];
                    for (int j = 0; j < matrix.Len; j++)
                    {
                        array[i][j] = Add(matrix[i, j], otherMatrix[i, j]);
                    }
                }
                return new SquareMatrix<T>(array);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static dynamic Add(dynamic x, dynamic y)
        {
            return (x + y);
        }
    }
}
