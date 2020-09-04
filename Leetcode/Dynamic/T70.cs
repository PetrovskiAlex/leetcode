using FluentAssertions;
using NUnit.Framework;

namespace Dynamic
{
    public class T70
    {
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 5)]
        [TestCase(5, 8)]
        [TestCase(6, 13)]
        public void TestClimbStairs(int n, int output)
        {
            var result = GetCountClimbStairs(n);

            result.Should().Be(output);
        }

        int GetCountClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            var previous = 2;
            var subPrevious = 1;

            var result = previous + subPrevious;
            for (var i = 3; i <= n; i++)
            {
                result = previous + subPrevious;
                subPrevious = previous;
                previous = result;
            }

            return result;
        }
    }
}