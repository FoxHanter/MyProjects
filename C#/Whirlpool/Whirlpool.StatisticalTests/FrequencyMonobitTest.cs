using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace Whirlpool.StatisticalTests
{
    public class FrequencyMonobitTest : IStatisticalTest
    {
        public double GetPValue(BitArray input)
        {
            var sum = 0.0;

            foreach (var bit in input)
                sum += (bool)bit ? 1 : -1;

            var stat = Math.Abs(sum) / Math.Sqrt(input.Length);
            var pValue = Special.Erfc(stat / Math.Sqrt(2));

            return pValue;
        }
    }
}
