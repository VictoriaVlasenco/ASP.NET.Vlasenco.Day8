﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task8Library
{
    public interface IMatrix<T>
    {
        int Len { get; }
        T this[int i, int j] { get; set; }
        event EventHandler<ValueChangedEventArgs<T>> ValueChanging;
    }

    public class SquareMatrix<T> : IMatrix<T>
    {
        private T[][] matrix;
        public event EventHandler<ValueChangedEventArgs<T>> ValueChanging;
        public SquareMatrix(T[][] array)
        {
            IMatrixValidator<T> validator = new SquareMatrixValidator<T>();
            if (validator.IsValid(array))
                CreateMatrix(array);
            else
                throw new Exception("The matrix is not square");
        }

        public T this[int i, int j]
        {
            get { return matrix[i][j]; }
            set
            {
                matrix[i][j] = value;
                OnValueChanging(new ValueChangedEventArgs<T>(i, j, value));
            }
        }

        public int Len
        {
            get { return matrix.Length; } 
        }

        protected virtual void OnValueChanging(ValueChangedEventArgs<T> eventArgs)
        {
            EventHandler<ValueChangedEventArgs<T>> temp = ValueChanging;

            if (temp != null)
            {
                temp(this, eventArgs);
            }
        }

        private void CreateMatrix(T[][] array)
        {
            matrix = new T[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                matrix[i] = new T[array.Length];
                array[i].CopyTo(matrix[i], 0);
            }
        }
    }

    public class SymmetricMatrix<T> : IMatrix<T>
    {
        private T[][] matrix;
        public event EventHandler<ValueChangedEventArgs<T>> ValueChanging;

        public SymmetricMatrix(T[][] array)
        {
            var validator = new SymmetricMatrixValidator<T>();
            if (validator.IsValid(array))
                CreateMatrix(array);
            else
                throw new Exception("The matrix is not symmetric");
        }

        public T this[int i, int j]
        {
            get { return matrix[i][j]; }
            set
            {
                if (i == j)
                {
                    matrix[i][j] = value;
                    OnValueChanging(new ValueChangedEventArgs<T>(i, j, value));

                }
                else
                {
                    matrix[i][j] = value;
                    OnValueChanging(new ValueChangedEventArgs<T>(i, j, value));
                    matrix[j][i] = value;
                    OnValueChanging(new ValueChangedEventArgs<T>(j, i, value));
                }
            }
        }

        public int Len
        {
            get { return matrix.Length; }
        }

        protected virtual void OnValueChanging(ValueChangedEventArgs<T> eventArgs)
        {
            EventHandler<ValueChangedEventArgs<T>> temp = ValueChanging;

            if (temp != null)
            {
                temp(this, eventArgs);
            }
        }

        private void CreateMatrix(T[][] array)
        {
            matrix = new T[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                matrix[i] = new T[i + 1];
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[i][j] = array[i][j];
                }
            }
        }
    }

    public class DiagonalMatrix<T> : IMatrix<T>
    {
        private T[] matrix;
        public event EventHandler<ValueChangedEventArgs<T>> ValueChanging;

        public DiagonalMatrix(T[][] array)
        {
            var validator = new DiagonalMatrixValidator<T>();
            if (validator.IsValid(array))
                CreateMatrix(array);
            else
                throw new Exception("The matrix is not diagonal");
        }

        public T this[int i, int j]
        {
            get
            {
                if (i != j)
                {
                    return default(T);
                }
                return matrix[i];
            }
            set
            {
                if (i == j)
                {
                    matrix[i] = value;
                    OnValueChanging(new ValueChangedEventArgs<T>(i, j, value));
                }
                else
                {
                    if (!value.Equals(default(T)))
                        throw new ArgumentException("The value changes matrix to nondiagonal.");
                    OnValueChanging(new ValueChangedEventArgs<T>(i, j, value));
                }
            }
        }

        public int Len
        {
            get { return matrix.Length; }
        }
        protected virtual void OnValueChanging(ValueChangedEventArgs<T> eventArgs)
        {
            EventHandler<ValueChangedEventArgs<T>> temp = ValueChanging;

            if (temp != null)
            {
                temp(this, eventArgs);
            }
        }
        private void CreateMatrix(T[][] array)
        {
            matrix = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                matrix[i] = array[i][i];
            }
        }
    }
}
