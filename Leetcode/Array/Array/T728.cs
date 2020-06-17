using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T728
    {
        [TestCase(1, 22, new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22})]
        public void Test(int left, int right, int[] output)
        {
            var result = new List<int>();

            for (var i = left; i <= right; i++)
            {
                if (IsSelfDividing(i))
                {
                    result.Add(i);
                }
            }

            result.Should().BeEquivalentTo(output);
        }

        private bool IsSelfDividing(int x)
        {
            var number = x;
            
            while (x != 0)
            {
                var digit = x % 10;
                if (digit == 0 || number % digit != 0)
                {
                    return false;
                }
                
                x /= 10;
            }

            return true;
        }
    }
}