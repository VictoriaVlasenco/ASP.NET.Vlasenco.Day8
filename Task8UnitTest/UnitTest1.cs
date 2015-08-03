using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8Library;

namespace Task8UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreatingSquareMatrix()
        {
            Matrix<int> m = new SquareMatrix<int>(new int[2][] { new int[2] { 1, 2 }, new int[2] { 2, 3 } });
            Matrix<int> m1 = new SquareMatrix<int>(new int[2][] { new int[2] { 1, 2 }, new int[2] { 2, 3 } });
            Assert.IsTrue(m.Equals( m1));
        }

        [TestMethod]
        public void AddingSquareMatrix()
        {
            Matrix<int> m = new SquareMatrix<int>(new int[2][] { new int[2] { 1, 2 }, new int[2] { 2, 3 } });
            Matrix<int> m1 = new SquareMatrix<int>(new int[2][] { new int[2] { 1, 2 }, new int[2] { 2, 3 } });
            Matrix<int> m2 = m.Add(m1);
            Matrix<int> m3 = new SquareMatrix<int>(new int[2][] { new int[2] { 2, 4 }, new int[2] { 4, 6 } });

            Assert.IsTrue(m2.Equals(m3));
        }
    }
}
