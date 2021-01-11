using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /// <summary>
    /// Running Sum of 1d Array
    /// Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
    /// </summary>
    public class T1480
    {
        [TestCase(new []{1,2,3,4}, new [] {1,3,6,10})]
        [TestCase(new []{1,1,1,1,1}, new [] {1,2,3,4,5})]
        public void Test(int[] input, int[] output)
        {
            var result = new int[input.Length];
            if (result.Length != 0)
            {
                result[0] = input[0];
            }

            for (var i = 1; i < input.Length; i++)
            {
                result[i] = result[i - 1] + input[i];
            }

            result.Should().Equal(output);
        }
    }
}