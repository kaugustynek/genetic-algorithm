using GA.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA.BasicTypes;
using GA.Helpers;

namespace GA.Implementations
{
    public class RouletteWheelSelection : ISelectionOperator
    {
        public void CalculateDistribuance(Individual[] currentPopulation, out List<double> distribuance)
        {
            var random = RandomProvider.Current;
            var sumOfFitness = currentPopulation
                .Sum(x => x.Fitness);

            double cummulativeFitness = 0;
            distribuance = currentPopulation
                .Select(x =>
                {
                    cummulativeFitness += x.Fitness / sumOfFitness;
                    return cummulativeFitness;
                })
                .ToList();
        }

        public Individual[] GenerateParentPopulation(Individual[] currentPopulation)
        {
            List<double> distribuance;

            CalculateDistribuance(currentPopulation, out distribuance);

            Console.WriteLine("--Distribuance");
            foreach (var item in distribuance)
            {
                Console.WriteLine(item);
            }

            return null;
        }
    }
}
