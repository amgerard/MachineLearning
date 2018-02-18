using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MachineLearning.LinearAlgebra;

namespace MachineLearning.UnitTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestConcat()
        {
            var a = new Matrix<int>(new int[,] { { 1, 2 } });
            var b = new Matrix<int>(new int[,] { { 3, 4 } });

            var c = a.Concat(b);
            var d = new Matrix<int>(new int[,] { { 1, 2 }, { 3, 4 } });

            Assert.AreEqual(c[0, 0], 1);
            Assert.AreEqual(c[1, 0], 3);
            Assert.IsTrue(c == d);
        }

        [TestMethod]
        public void TestInv2x2()
        {
            var i3x3 = new Matrix<double>(new double[,] { { 1.0, 0, 0 }, { 0, 1.0, 0 }, { 0, 0, 1.0 } });
            var i2x2 = new Matrix<double>(new double[,] { { 1.0, 0.0 }, { 0.0, 1.0 } });

            // testing inverse
            var a = new Matrix<double>(new double[,] { { 3, 0, 2 }, { 2, 0, -2 }, { 0, 1, 1 } });
            var a_inv = MatrixInverseExtensions.Inv3x3(a);
            var i = a * a_inv;
            Assert.IsTrue(i == i3x3);

            // testing inverse
            a = new Matrix<double>(new double[,] { { 1.0, 3.0 }, { 2.0, 1.0 } });
            a_inv = MatrixInverseExtensions.Inv2x2(a);
            i = a * a_inv;
            //Assert.IsTrue(i == i2x2);

            //ii = new Matrix<double>(new double[,] { { 0.5, 0.75 }, { 1.3, 0.1 } });
            //ii_inv = inv2x2(ii);
            //i = ii * ii_inv;
            //Console.Write(i.ToString());

            //ii = new Matrix<double>(new double[,] { { 2, 5 }, { 1, 10 } });
            //ii_inv = inv2x2(ii);
            //i = ii * ii_inv;
            //Console.Write(i.ToString());
        }

        [TestMethod]
        public void TestArith()
        {
            var a = new Matrix<double>(5, 5, 1.1);
            var b = new Matrix<double>(5, 5, 3.4);
            var c = a + b;
            Console.Write(c.ToString());

            var d = c - a;
            Console.Write(d.ToString());

            d = d - 10;
            Console.Write(d.ToString());

            var e = new Matrix<double>(2, 1, 2);
            var f = new Matrix<double>(1, 2, 3);
            Console.Write((e * f).ToString());

            e = new Matrix<double>(1, 2, 2);
            f = new Matrix<double>(2, 1, 3);
            Console.Write((e * f).ToString());

            var g = new Matrix<double>(2, 1, 1.1);
            Console.Write(g.ToString());
            Console.Write(g.Transpose.ToString());

            // test equals
            Console.Write("Should be true: " + (a + b == b + a));
            Console.Write("Should be false: " + (a + b != b + a));
        }

        [TestMethod]
        public void TestIndexing()
        {
            var a = new Matrix<double>(new double[,] { { 3, 0, 2 }, { 2, 0, -2 }, { 0, 1, 1 } });
            var b = a[new[] { 0, 2 }, new[] { 0, 2 }];
            var c = new Matrix<double>(new double[,] { { 3, 2 }, { 0, 1 } });
            Assert.IsTrue(b == c);
        }
    }
}
