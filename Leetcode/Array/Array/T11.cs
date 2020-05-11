using System;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * 11. Container With Most Water
     * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.
     */
    public class T11
    {
        [TestCase(new []{1,8,6,2,5,4,8,3,7}, 49)]
        [TestCase(new []{1,2,3,15,15,1,2}, 15)]
        [TestCase(new []{1,2,3,4,1,2}, 8)]
        [TestCase(new []{0,2}, 0)]
        public void Test(int[] numbers, int output)
        {
            var result = 0;

            for (var i = 0; i < numbers.Length; i++)
            {
                var value = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    var next = numbers[j];
                    var product = Math.Min(value, next) * (j - i);
                    if (product > result)
                    {
                        result = product;
                    }
                }
            }

            result.Should().Be(output);
        }
    }
}