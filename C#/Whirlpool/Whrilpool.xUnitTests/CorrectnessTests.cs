using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whirlpool.StatisticalTests;
using Xunit;

namespace Whirlpool.Tests
{
    public class CorrectnessTests
    {
        [Theory]
        [InlineData("1100100100001111110110101010001000100001011010001100001000110100110001001100011001100010100010111000")]
        public void FrequencyMonobitTest_ReturnsCorrectValue(string input)
        {
            var testValue = FromOnesAndZeroesToBit(input);
            var frequencyMonobitTest = new FrequencyMonobitTest();

            var expected = 0.109599;
            var actual = frequencyMonobitTest.GetPValue(testValue);

            Assert.True(AreEqual(expected, actual));
        }

        [Theory]
        [InlineData("1100100100001111110110101010001000100001011010001100001000110100110001001100011001100010100010111000")]
        public void FrequencyBlockTest_ReturnsCorrectValue(string input)
        {
            var testValue = FromOnesAndZeroesToBit(input);
            var blockLength = 10;
            var frequencyBlockTest = new FrequencyBlockTest(blockLength);

            var expected = 0.706438;
            var actual = frequencyBlockTest.GetPValue(testValue);

            Assert.True(AreEqual(expected, actual));
        }

        [Theory]
        [InlineData("1100100100001111110110101010001000100001011010001100001000110100110001001100011001100010100010111000")]
        public void RunsTest_ReturnsCorrectValue(string input)
        {
            var testValue = FromOnesAndZeroesToBit(input);
            var runsTest = new RunsTest();

            var expected = 0.500798;
            var actual = runsTest.GetPValue(testValue);

            Assert.True(AreEqual(expected, actual));
        }

        [Theory]
        [InlineData("01011001001010101101")]
        public void BinaryMatrixRankTest_ReturnsCorrectValue(string input)
        {
            var testValue = FromOnesAndZeroesToBit(input);
            var binaryMatrixRankTest = new BinaryMatrixRankTest(3, 3);

            var expected = 0.741948;
            var actual = binaryMatrixRankTest.GetPValue(testValue);

            Assert.True(AreEqual(expected, actual));
        }

        [Theory]
        [InlineData("1100100100001111110110101010001000100001011010001100001000110100110001001100011001100010100010111000")]
        public void CumulativeSumsTest_InForwardMode_ReturnsCorrectValue(string input)
        {
            var testValue = FromOnesAndZeroesToBit(input);
            var cusumTest = new CumulativeSumsTests(0);

            var expected = 0.219194;
            var actual = cusumTest.GetPValue(testValue);

            Assert.True(AreEqual(expected, actual));
        }

        [Theory]
        [InlineData("1100100100001111110110101010001000100001011010001100001000110100110001001100011001100010100010111000")]
        public void CumulativeSumsTest_InBackwardMode_ReturnsCorrectValue(string input)
        {
            var testValue = FromOnesAndZeroesToBit(input);
            var cusumTest = new CumulativeSumsTests(1);

            var expected = 0.114866;
            var actual = cusumTest.GetPValue(testValue);

            Assert.True(AreEqual(expected, actual));
        }

        private bool AreEqual(double expected, double actual)
        {
            var eps = 0.000001;
            return Math.Abs(expected - actual) < eps;
        }

        private BitArray FromOnesAndZeroesToBit(string input)
        {
            var bools = new bool[input.Length];

            for (int i = 0; i < input.Length; i++)
                bools[i] = input[i] == '1' ? true : false;

            return new BitArray(bools);
        }
    }
}
