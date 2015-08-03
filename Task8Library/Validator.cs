using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task8Library
{

    public interface IMatrixValidator<T>
    {
        bool IsValid(T[][] array);
    }

    public class SquareMatrixValidator<T> : IMatrixValidator<T>
    {
        public bool IsValid(T[][] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("The array is empty");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                    throw new ArgumentException("The array is empty");
                if (array[i].Length != array.Length)
                    return false;
            }
            return true;
        }
    }

    public class SymmetricMatrixValidator<T> : IMatrixValidator<T>
    {
        private readonly SquareMatrixValidator<T> validator = new SquareMatrixValidator<T>();
        public bool IsValid(T[][] array)
        {
            if (!validator.IsValid(array))
                return false;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!array[i][j].Equals(array[j][i])) return false;
                }
            }
            return true;
        }
    }

    public class DiagonalMatrixValidator<T> : IMatrixValidator<T>
    {
        private readonly SymmetricMatrixValidator<T> validator = new SymmetricMatrixValidator<T>();

        public bool IsValid(T[][] array)
        {
            if (!validator.IsValid(array))
                return false;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!array[i][j].Equals(default(T))) return false;
                }
            }
            return true;
        }
    }
}
