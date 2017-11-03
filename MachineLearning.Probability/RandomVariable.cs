using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.Probability
{
    public class RandomVariable
    {
        private readonly IDistribution _distribution;

        public RandomVariable(IDistribution distribution)
        {
            _distribution = distribution;
        }
    }
}
