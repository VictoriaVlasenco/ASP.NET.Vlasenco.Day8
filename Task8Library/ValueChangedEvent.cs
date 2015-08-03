using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Library
{
    public sealed class ValueChangedEventArgs<T> : EventArgs
    {
        private readonly int rowNumber;
        private readonly int columnNumber;
        private readonly T value;
        public ValueChangedEventArgs(int iIndex, int jIndex, T value)
        {
            rowNumber = iIndex;
            columnNumber = jIndex;
            this.value = value;
        }
        public int RowNumber { get { return rowNumber; } }
        public int ColumnNumber { get { return columnNumber; } }
        public T Value {get { return value; }}
    }
}
