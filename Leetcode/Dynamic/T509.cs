using FluentAssertions;
using NUnit.Framework;

namespace Dynamic
{
    public class T509
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        public void TestFib(int number, int output)
        {
            GetFib(number).Should().Be(output);
        }
        
        int GetFib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            var previous = 1;
            var subPrevious = 0;

            var result = previous + subPrevious;
            for (var i = 2; i <= n; i++)
            {
                result = previous + subPrevious;
                subPrevious = previous;
                previous = result;
            }

            return result;
        }
    }
}