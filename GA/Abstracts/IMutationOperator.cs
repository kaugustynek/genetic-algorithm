using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GA.BasicTypes;

namespace GA.Abstracts
{

    interface IMutationOperator
    {
        void Mutation(Individual parent, double mutationProbability);
    }

}