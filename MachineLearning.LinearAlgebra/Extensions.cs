using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.LinearAlgebra
{
    public struct ValAndIdx<T>
    {
        public T Val;
        public int Idx;
    }

    public static class Extensions
    {
        public static IEnumerable<ValAndIdx<T>> ValsAndIdxs<T>(this IEnumerable<T> vals)
        {
            return vals.Select((v,i) => new ValAndIdx<T> { Val = v, Idx = i });
        }
    }
}
