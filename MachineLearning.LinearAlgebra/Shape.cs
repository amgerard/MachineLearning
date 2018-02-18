using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.LinearAlgebra
{
    public struct Shape
    {
        public int N;
        public int D;

        public int this[int dim]
        {
            get { return dim == 0 ? N : D; }
            set
            {
                if (dim == 0) N = value;
                else D = value;
            }
        }

        public Shape Transpose
        {
            get { return new Shape(D, N); }
        }

        public Shape(int n, int d)
        {
            N = n;
            D = d;
        }

        public Shape Copy() { return new Shape(N, D); }

        public static bool operator ==(Shape a, Shape b)
        {
            return a.N == b.N && a.D == b.D;
        }

        public static bool operator !=(Shape a, Shape b)
        {
            return !(a == b);
        }
    }
}
