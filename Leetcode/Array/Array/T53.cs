using System;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T53
    {
        [TestCase(new []{-2,1,-3,4,-1,2,1,-5,4}, 6)]
        public void Test(int[] nums, int result)
        {
            var sum = 0;
            var maxSum = int.MinValue;

            foreach (var num in nums)
            {
                sum += num;
                if (num > sum)
                {
                    sum = num;
                }

                maxSum = Math.Max(sum, maxSum);
            }

            maxSum.Should().Be(result);
        }
    }
}