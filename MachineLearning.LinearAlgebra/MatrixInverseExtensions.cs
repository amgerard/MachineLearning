using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.LinearAlgebra
{
    public static class MatrixInverseExtensions
    {
        public static Matrix<double> Inv3x3(Matrix<double> X)
        {
            if (X.Shape.D != 3)
                throw new Exception();

            var a = X[0, 0];
            var b = X[0, 1];
            var c = X[0, 2];

            var m1 = X.Sub(1, 1, 3, 3);
            var m2 = X.Sub(1, 0, 3, 1).Concat(X.Sub(1, 2, 3, 3), 1);
            var m3 = X.Sub(1, 0, 3, 2);

            var det = a * Det(m1) - b * Det(m2) + c * Det(m3);

            var c11 = Det(m1);
            var c12 = Det(m2);
            var c13 = Det(m3);

            var c21 = Det(X.Sub(0, 1, 1, 3).Concat(X.Sub(2, 1, 3, 3), 0));
            var m22 = X[new[] { 0, 2 }, new[] { 0, 2 }];
            var c22 = Det(m22);
            var c23 = Det(X.Sub(0, 0, 1, 2).Concat(X.Sub(2, 0, 3, 2), 0));

            var c31 = Det(X.Sub(0, 1, 2, 3));
            var c32 = Det(X.Sub(0, 0, 2, 1).Concat(X.Sub(0, 2, 2, 3), 1));
            var c33 = Det(X.Sub(0, 0, 2, 2));

            var m = new Matrix<double>(new double[,] { { c11, -c12, c13 },
                                                       {-c21, c22, -c23 },
                                                       { c31, -c32, c33 } });
            var adjugate = m.Transpose;
            return (1 / det) * adjugate;
        }

        public static Matrix<double> Inv2x2(Matrix<double> X)
        {
            if (X.Shape.D != 2)
                throw new Exception();

            // 1 3  -1/5  3/5 
            // 2 1   2/5 -1/5
            //
            // 
            //
            // det = 1 - 6 = -5
            // -1/5 * [1 -2; -3 1]

            // inv(X) = (1 / det(X)) * 
            // X'*X*w = X'*y
            // w = inv(X' * X) * X' * y
            var a = X[0, 0];
            var b = X[0, 1];
            var c = X[1, 0];
            var d = X[1, 1];

            // a*a1 + b*c1 = 1
            // c*a1 + d*c1 = 0
            // a*b1 + b*d1 = 0
            // c*b1 + d*c1 = 1
            
            var det = a * d - b * c;
            // det = b * c - a * d;
            var m = new Matrix<double>(new double[,] { { d, -b },
                                                       { -c, a } });
            return (1 / det) * m;
        }

        public static double Det(Matrix<double> X)
        {
            var a = X[0, 0];
            var b = X[0, 1];
            var c = X[1, 0];
            var d = X[1, 1];

            // a*a1 + b*c1 = 1
            // c*a1 + d*c1 = 0
            // a*b1 + b*d1 = 0
            // c*b1 + d*c1 = 1

            return a * d - b * c;
        }
    }
}
