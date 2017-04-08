using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GA.BasicTypes
{
    class Individual
    {
        public ChromosomeType Chromosome { get; set; }
        public double Fitness { get; set; }

        public Individual(int chromosomeSize)
        {
            Chromosome = new ChromosomeType(chromosomeSize);
        }

        public void UpdateFitness(Func<double, double> fitness)
        {
            Fitness = fitness(Chromosome.DecodedValue);
        }
    }
}
