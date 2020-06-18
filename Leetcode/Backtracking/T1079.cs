using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T1079
    {
        [TestCase("AAB", 8)]
        [TestCase("AAABBC", 188)]
        public void Test(string tiles, int output)
        {
            var result = 0;

            result.Should().Be(output);
        }
    }
}