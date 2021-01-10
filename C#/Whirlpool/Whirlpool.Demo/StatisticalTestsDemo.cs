using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whirlpool.StatisticalTests;

namespace Whirlpool.Demo
{
    class StatisticalTestsDemo
    {
        private const double EXPECTED_VALUE = 0.01;

        private readonly IEnumerable<IStatisticalTest> _statisticalTests;
        private readonly BitArray _testValue;

        public StatisticalTestsDemo(byte[] testValue)
        {
            _testValue = new BitArray(testValue);
            _statisticalTests = new List<IStatisticalTest>
            {
                new FrequencyMonobitTest(),//Частотный тест
                new FrequencyBlockTest(),//Частотный блочный тест
                new RunsTest(),//Тест «дырок» 
                new BinaryMatrixRankTest(),//Тест рангов бинарных матриц
                new CumulativeSumsTests() //Тест кумулятивных сумм
            };
        }

        public void Run()
        {
            foreach (var test in _statisticalTests)
                GetTestResult(test);

            Console.ReadLine();
        }

        private void GetTestResult(IStatisticalTest test)
        {
            var pValue = test.GetPValue(_testValue);
            var result = pValue >= EXPECTED_VALUE
                ? "Последовательность случайна"
                : "Последовательность неслучайна";

            Console.WriteLine(test.GetType().Name);
            Console.WriteLine($"P-значение: {pValue}");
            Console.WriteLine($"Результат: {result}\n");
        }
    }
}
