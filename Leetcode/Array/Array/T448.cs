using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T448
    {
        /*
         * 448. Find All Numbers Disappeared in an Array
         */
        [TestCase(new []{4,3,2,7,8,2,3,1}, new [] {5,6})]
        [TestCase(new []{1,1,1}, new [] {2,3})]
        public void Test(int[] nums, int[] output)
        {
            if (!nums.Any()) return;

            for (var i = 0; i < nums.Length; i++)
            {
                var el = Math.Abs(nums[i]);

                if (nums[el - 1] > 0)
                {
                    nums[el - 1] = -nums[el - 1];
                }
            }

            var result = new List<int>();
            for (var k = 0; k < nums.Length; k++)
            {
                if (nums[k] > 0)
                {
                    result.Add(k + 1);
                }
            }

            result.Should().BeEquivalentTo(output);
        }
    }
}