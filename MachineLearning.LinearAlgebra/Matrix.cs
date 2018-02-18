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

        public Matrix<T> this[IEnumerable<int> ixs, IEnumerable<int> jxs]
        {
            get
            {
                var result = new Matrix<T>(ixs.Count(), jxs.Count());
                foreach (var ix in ixs.ValsAndIdxs())
                    foreach (var jx in jxs.ValsAndIdxs())
                        result[ix.Idx, jx.Idx] = this[ix.Val, jx.Val];
                return result;
            }
            // set { matrix[i, j] = value; }
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

        public Matrix(T[,] matrix_in)
        {
            matrix = matrix_in;
            Shape = new Shape(matrix.GetLength(0), matrix.GetLength(1));
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

        public Matrix<T> Sub(int r1, int c1, int r2, int c2)
        {
            var aSub = new Matrix<T>(r2 - r1, c2 - c1);
            for (int i = r1; i < r2; i++)
                for (int j = c1; j < c2; j++)
                    aSub[i - r1, j - c1] = this[i, j];
            return aSub;
        }

        public Matrix<T> Concat(Matrix<T> concatMatrix, int dim = 0)
        {
            var matchingDim = dim == 0 ? 1 : 0;
            if (this.Shape[matchingDim] != concatMatrix.Shape[matchingDim])
                throw new Exception();

            var concatShape = this.Shape.Copy();
            concatShape[dim] = this.Shape[dim] + concatMatrix.Shape[dim];
            var concat = new Matrix<T>(concatShape);
            MatrixExtensions.DoOperation(concat, this, x => x, true);
            var iStart = dim == 0 ? this.Shape.N : 0;
            var jStart = dim == 1 ? this.Shape.D : 0;
            MatrixExtensions.DoOperation(concat, concatMatrix, x => x, true, iStart, jStart);
            return concat;
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
