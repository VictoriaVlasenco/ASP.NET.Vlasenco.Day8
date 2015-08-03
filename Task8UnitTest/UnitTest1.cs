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

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SquareMatrix_ExceptionExpected()
        {
            Matrix<int> m = new SquareMatrix<int>(new int[2][] { new int[2] { 1, 2 }, new int[3] { 2, 3 ,4} });
        }

        [TestMethod]
        public void CreatingSymmetricMatrix()
        {
            Matrix<int> m = new SymmetricMatrix<int>(new int[3][]
            {
                new int[3] {1, 2, 3},
                new int[3] {2, 3, 4}, new int[3] {3, 4, 5}
            });

        }

        [TestMethod]
        public void AddingSymmetricMatrix()
        {
            Matrix<int> m = new SymmetricMatrix<int>(new int[3][]
            {
                new int[3] {1, 2, 3},
                new int[3] {2, 3, 4}, new int[3] {3, 4, 5}
            });
            Matrix<int> m2 = new SymmetricMatrix<int>(new int[3][]
            {
                new int[3] {1, 2, 3},
                new int[3] {2, 3, 4}, new int[3] {3, 4, 5}
            });
            Matrix<int> m1 = m.Add(m2);
            Assert.IsTrue(new SquareMatrix<int>(new int[3][]
            {
                new int[3] {2, 4, 6},
                new int[3] {4, 6, 8}, new int[3] {6, 8, 10}
            }).Equals(m1));
        }

        [TestMethod]
        public void AddingDiagonalMatrix()
        {
            Matrix<int> m = new DiagonalMatrix<int>(new int[2][] { new int[2] { 1, 0 }, new int[2] { 0, 3 } });
            Matrix<int> m1 = new DiagonalMatrix<int>(new int[2][] { new int[2] { 1, 0 }, new int[2] { 0, 3 } });
            Matrix<int> m2 = m.Add(m1);
            Matrix<int> m3 = new SquareMatrix<int>(new int[2][] { new int[2] { 2, 0 }, new int[2] { 0, 6 } });

            Assert.IsTrue(m2.Equals(m3));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatingDiagonalMatrix_ExcpectedException()
        {
            Matrix<int> m = new DiagonalMatrix<int>(new int[2][] { new int[2] { 1, 0 }, new int[2] { 2, 3 } });
        }
    }
}
