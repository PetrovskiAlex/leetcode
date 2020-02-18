using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T169
    {
        [TestCase(new []{3,2,3}, 3)]
        [TestCase(new []{2,2,1,1,1,2,2}, 2)]
        public void Test(int[] nums, int result)
        {
            int count = 0;
            int? candidate = null;

            foreach (var num in nums) {
                if (count == 0) {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }

            candidate.Should().Be(result);
        }
    }
}