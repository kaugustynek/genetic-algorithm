using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GA.Extensions;

namespace GA.BasicTypes
{
    class ChromosomeType
    {
        private static Random _random = new Random();
        public bool[] Chromosome { get; set; }
        public double DecodedValue { get { return GetDecodedValue(); } }

        public ChromosomeType(int chromosomeSize)
        {
            Chromosome = new bool[chromosomeSize];

            for (int i = 0; i < Chromosome.Length; i++)
            {
                Chromosome[i] = _random.NextBool();
            }
        }

        private double GetDecodedValue()
        {
            throw new NotImplementedException();
        }
    }

}
