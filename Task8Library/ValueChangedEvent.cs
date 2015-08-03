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

    public class ValueChangedMenager<T>
    {
        public event EventHandler<ValueChangedEventArgs<T>> ValueChanging;

        public virtual void OnValueChanging(ValueChangedEventArgs<T> eventArgs)
        {
            EventHandler<ValueChangedEventArgs<T>> temp = ValueChanging;

            if (temp != null)
            {
                temp(this, eventArgs);
            }
        }
    }
}
