using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T136
    {
        [TestCase(new []{2,2,1}, 1)]
        [TestCase(new []{4,1,2,1,2}, 4)]
        public void Test(int[] nums, int result)
        {
            var first = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                first ^= nums[i];
            }

            first.Should().Be(result);
        }
    }
}