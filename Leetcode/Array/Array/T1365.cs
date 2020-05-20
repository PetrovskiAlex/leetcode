using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * 1365. How Many Numbers Are Smaller Than the Current Number
     */
    public class T1365
    {
        [TestCase(new [] {8,1,2,2,3}, new [] {4,0,1,1,3})]
        [TestCase(new [] {7,7,7,7}, new [] {0,0,0,0})]
        public void Test(int[] nums, int[] output)
        {
            var sortedNums = nums.OrderBy(i => i).ToArray();

            var map = new Dictionary<int, int>();
            for (var i = 0; i < sortedNums.Length; i++)
            {
                var count = CountSmallerNumbers(sortedNums, i);
                map[sortedNums[i]] = count;
            }

            var result = nums.Select(num => map[num]).ToList();

            result.Should().BeEquivalentTo(output);
        }

        private int CountSmallerNumbers(int[] nums, int index)
        {
            var el = nums[index];
            while (index > 0)
            {
                if (nums[index] != nums[index - 1])
                {
                    break;
                }

                index--;
            }

            return index;
        }
    }
}