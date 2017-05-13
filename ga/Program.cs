﻿using GA.BasicTypes;
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
            double[] x1 = { 1, 2, 3, 4, 5 };

            double[] y = x1.Select(m => m).ToArray();

            y[1] = 50;

            Console.WriteLine($"{x1[1]} != {y[1]}");

            return;

            Func<double, double> fitness = x => 2 * x + 1;
            var ga = new GeneticAlgorithm(6, 10,
                new OnePointCrossover(),
                new ClassicMutationOperator(),
                new RouletteWheelSelection(),
                fitness);
            ga.PrintStatistics = true;
            var result = ga.RunSimulation(500);

            Console.WriteLine($"x = {result.Chromosome.DecodedValue}, f = {result.Fitness}");

            var ind = new Individual(10);
            ind.ReplaceGenes(new bool[] { true, true, true, true, true, true, true, true, true, true });
            Console.WriteLine($"x = {ind.Chromosome.DecodedValue}, f = {fitness(ind.Chromosome.DecodedValue)}");

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
