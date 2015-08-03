using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8Library;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IMatrix<int> m = new SquareMatrix<int>(new int[2][] { new int[2] { 1, 2 }, new int[2] { 2, 3 } });
            IMatrix<int> m1 = new SquareMatrix<int>(new int[2][] { new int[2] { 1, 2 }, new int[2] { 2, 3 } });
            IMatrix<int> m2 = m.Add(m1);

            m1.ValueChanging += Msg;
            m1[0,0] = 10;

            Console.Read();
        }
        private static void Msg<T>(Object sender, ValueChangedEventArgs<T> ea )
        {
            Console.WriteLine("Raw: {0}, Col: {1}, Changed by value: {2}", ea.RowNumber, ea.ColumnNumber, ea.Value);
        }
    }
}
