using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whirlpool.StatisticalTests
{
    public interface IStatisticalTest
    {
        double GetPValue(BitArray input);
    }
}
