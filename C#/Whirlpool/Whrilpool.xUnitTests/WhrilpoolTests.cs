using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whirlpool.Core;
using Xunit;

namespace Whirlpool.Tests
{
    public class WhrilpoolTests
    {
        private readonly Whirlpool_Algorithm _blake;

        public WhrilpoolTests()
        {
            _blake = new Whirlpool_Algorithm();
        }

        [Fact]
        public void ComputeHash_ReturnsCorrectHash_1()
        {
            var testString = "The quick brown fox jumps over the lazy dog";

            var expected = "b97de512e91e3828b40d2b0fdce9ceb3c4a71f9bea8d88e75c4fa854df36725fd2b52eb6544edcacd6f8beddfea403cb55ae31f03ad62a5ef54e42ee82c3fb35";
            var actual =_blake.display(_blake.Start(testString));

            Assert.True(AreEqual(expected, actual));
        }

        [Fact]
        public void ComputeHash_ReturnsCorrectHash_2()
        {
            var testString = "The quick brown fox jumps over the lazy eog";

            var expected = "C27BA124205F72E6847F3E19834F925CC666D0974167AF915BB462420ED40CC50900D85A1F923219D832357750492D5C143011A76988344C2635E69D06F2D38C";
            var actual = _blake.display(_blake.Start(testString));

            Assert.True(AreEqual(expected, actual));
        }

        [Fact]
        public void ComputeHash_ReturnsCorrectHash_3()
        {
            var testString = "";

            var expected = "19FA61D75522A4669B44E39C1D2E1726C530232130D407F89AFEE0964997F7A73E83BE698B288FEBCF88E3E03C4F0757EA8964E59B63D93708B138CC42A66EB3";
            var actual = _blake.display(_blake.Start(testString));

            Assert.True(AreEqual(expected, actual));
        }

        [Fact]
        public void ComputeHash_ReturnsCorrectHash_4()
        {
            var testString = "Hello world";

            var expected = "69059b5a5afe634b484da83034ce906343d453a6006c1119b1ee8963b4836396aea8b5565e9f67eeca7b08e608e79e7986a109151b0ff3267827722e7e1b1ab4";
            var actual = _blake.display(_blake.Start(testString));

            Assert.True(AreEqual(expected, actual));
        }

        [Fact]
        public void ComputeHash_ReturnsTheSameHashesOnTheSameInputs()
        {
            var testString = Guid.NewGuid().ToString();

            var firstHash = _blake.Start(testString);
            var secondHash = _blake.Start(testString);

            Assert.Equal(firstHash, secondHash);
        }

        private bool AreEqual(string expected, string actual)
        {
            return expected.ToLower() == actual.ToLower().Replace(" ", "");
        }
    }
}
