using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.LinearAlgebra
{
    public class MatrixExtensions
    {
        public static Matrix<T> DoOperation<T>(Matrix<T> a, Matrix<T> b, Func<T, T, T> op)
        {
            if (a.Shape != b.Shape)
                throw new Exception();

            var aOpB = new Matrix<T>(a.Shape);
            for (int i = 0; i < a.Shape.N; i++)
                for (int j = 0; j < a.Shape.D; j++)
                    aOpB[i, j] = op(a[i, j], b[i, j]);

            return aOpB;
        }

        public static Matrix<T> DoInnerOperation<T>(Matrix<T> a, Matrix<T> b, Func<T, T, T> op)
        {
            if (a.Shape.D != b.Shape.N)
                throw new Exception();

            var aOpB = new Matrix<T>(a.Shape.N, b.Shape.D);
            for (int i = 0; i < aOpB.Shape.N; i++)
                for (int j = 0; j < aOpB.Shape.D; j++)
                    aOpB[i, j] = Enumerable.Range(0, a.Shape.D)                 // inner count
                                           .Select(x => op(a[i, x], b[x, j]))   // op
                                           .Aggregate((x,y) => (dynamic)x + y); // sum

            return aOpB;
        }

        public static Matrix<T> DoOperation<T>(Matrix<T> a, Func<T, T> op, bool inPlace = false)
        {
            var aOpX = inPlace ? a : new Matrix<T>(a.Shape);
            for (int i = 0; i < a.Shape.N; i++)
                for (int j = 0; j < a.Shape.D; j++)
                    aOpX[i, j] = op(a[i, j]);
            return aOpX;
        }
    }
}
