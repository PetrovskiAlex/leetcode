using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T33
    {
        /*
         * 33. Search in Rotated Sorted Array
         */
        [TestCase(new [] {4,5,6,7,0,1,2}, 0, 4)]
        [TestCase(new [] {4,5,6,7,0,1,2}, 3, -1)]
        [TestCase(new [] {4,5,6,7,0,1,2}, 5, 1)]
        [TestCase(new [] {4,5,6,7,0,1,2}, 4, 0)]
        public void Test(int[] nums, int target, int expected)
        {
            var result = -1;

            result = Search(nums, 0, nums.Length, target);

            result.Should().Be(expected);
        }

        private int Search(int[] nums, int low, int high, int target)
        {
            if (low > high || low >= nums.Length) return -1;
            if (low == high && nums[low] == target) return low;
            if (nums[low] == target) return low;
            if (high < nums.Length && nums[high] == target) return high;

            var middle = (low + high) / 2;
            if (nums[middle] == target) return middle;

            var result = Search(nums, low, middle - 1, target);
            if (result > -1) return result;

            result = Search(nums, middle + 1, high, target);

            return result;
        }
    }
}