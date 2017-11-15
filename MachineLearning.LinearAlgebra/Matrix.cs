using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.LinearAlgebra
{
    public class Matrix<T>
    {
        private T[,] matrix;
        public Shape Shape;

        public T this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public Matrix(int n, int d)
        {
            init(n, d);
        }

        public Matrix(Shape shape)
        {
            init(shape.N, shape.D);
        }

        public Matrix(int n, int d, T defaultValue)
        {
            init(n, d);
            MatrixExtensions.DoOperation(this, x => defaultValue, true);
        }

        private void init(int n, int d)
        {
            matrix = new T[n, d];
            Shape = new Shape(n, d);
        }

        public Matrix<T> Transpose
        {
            get
            {
                var aTrans = new Matrix<T>(Shape.Transpose);
                for (int i = 0; i < Shape.N; i++)
                    for (int j = 0; j < Shape.D; j++)
                        aTrans[j, i] = this[i, j];
                return aTrans;
            }
        }

        public Matrix<T> Inverse
        {
            get
            {
                var aTrans = new Matrix<T>(Shape.Transpose);
                return aTrans;
            }
        }

        public override string ToString()
        {
            var str = "";
            for (int i = 0; i < Shape.N; i++)
            {
                for (int j = 0; j < Shape.D; j++)
                    str += (this[i, j] + "\t");
                str += Environment.NewLine;
            }
            return str;
        }

        #region overload arithmitic and equals

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            return MatrixExtensions.DoOperation(a, b, (i, j) => (dynamic)i + j);
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            return MatrixExtensions.DoOperation(a, b, (i, j) => (dynamic)i - j);
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            return MatrixExtensions.DoInnerOperation(a, b, (i, j) => (dynamic)i * j);
        }

        public static Matrix<T> operator +(Matrix<T> a, T x)
        {
            return MatrixExtensions.DoOperation(a, i => (dynamic)i + x);
        }

        public static Matrix<T> operator -(Matrix<T> a, T x)
        {
            return MatrixExtensions.DoOperation(a, i => (dynamic)i - x);
        }

        public static Matrix<T> operator *(Matrix<T> a, T x)
        {
            return MatrixExtensions.DoOperation(a, i => (dynamic)i * x);
        }

        public static Matrix<T> operator *(T x, Matrix<T> a)
        {
            return MatrixExtensions.DoOperation(a, i => (dynamic)i * x);
        }

        public static Matrix<T> operator /(Matrix<T> a, T x)
        {
            return MatrixExtensions.DoOperation(a, i => (dynamic)i / x);
        }

        public static bool operator ==(Matrix<T> a, Matrix<T> b)
        {
            return (a.Shape == b.Shape) && (a - b).matrix.Cast<T>().All(x => (dynamic)x == 0);
        }

        public static bool operator !=(Matrix<T> a, Matrix<T> b)
        {
            return !(a == b);
        }

        #endregion
    }
}
