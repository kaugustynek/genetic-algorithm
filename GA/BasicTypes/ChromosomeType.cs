using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GA.Extensions;
using GA.Helpers;

namespace GA.BasicTypes
{
    public class ChromosomeType
    {
        public int Size { get { return Genes.Count(); } }

        public bool this[int index]
        {
            get { return Genes[index]; }
            set { Genes[index] = value; }
        }

        public bool[] Genes { get; set; }
        public double DecodedValue { get { return GetDecodedValue(); } }

        public ChromosomeType(int chromosomeSize)
        {
            var random = RandomProvider.Current;

            Genes = new bool[chromosomeSize];
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = random.NextBool();
            }
        }

        private double GetDecodedValue()
        {
            return Genes
                .Reverse()
                .Select((x, i) => (x ? Math.Pow(2, i) : 0))
                .Sum();
        }
    }

}
