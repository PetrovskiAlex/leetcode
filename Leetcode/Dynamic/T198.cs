using System;
using FluentAssertions;
using NUnit.Framework;

namespace Dynamic
{
    public class T198
    {
        [TestCase(new [] {1,2,3,1}, 4)]
        [TestCase(new [] {2,7,9,3,1}, 12)]
        [TestCase(new [] {2,1,1,2}, 4)]
        public void TestRob(int[] nums, int output)
        {
            var result = 0;

            var even = 0;
            var odd = 0;
    
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even = Math.Max(even + nums[i], odd);
                }
                else
                {
                    odd = Math.Max(odd + nums[i], even);
                }
            }

            result = Math.Max(even, odd);
            result.Should().Be(output);
        }
    }
}