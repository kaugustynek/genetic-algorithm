using GA.BasicTypes;
using GA.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    class Program
    {
        static void Main(string[] args)
        {
            var ga = new GeneticAlgorithm(6, 6, new OnePointCrossover(), new ClassicMutationOperator(), new RouletteWheelSelection(), x => 2 * x + 1);
            ga.RunSimulation(100);

            return;

            var ind1 = new Individual(10);
            var ind2 = new Individual(10);

            Console.WriteLine("Individual 1: ");
            Console.WriteLine(ind1);
            Console.WriteLine("Individual 2: ");
            Console.WriteLine(ind2);

            var crossover = new OnePointCrossover();

            crossover.Crossover(ind1, ind2);

            Console.WriteLine("Individual 1: ");
            Console.WriteLine(ind1);
            Console.WriteLine("Individual 2: ");
            Console.WriteLine(ind2);

            var mutation = new ClassicMutationOperator();


            Console.WriteLine("--Before mutation: ");
            Console.WriteLine("Individual 1: ");
            Console.WriteLine(ind1);

            mutation.Mutation(ind1, 0.1);

            Console.WriteLine("--After mutation: ");
            Console.WriteLine("Individual 1: ");
            Console.WriteLine(ind1);
        }
    }
}
