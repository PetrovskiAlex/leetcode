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
        [TestCase(new [] {4,5,6,7,8,0,1,2}, 0, 5)]
        [TestCase(new [] {4,5,6,7,8,9,1}, 1, 6)]
        [TestCase(new [] {4,5,6,7,8,1,2}, 1, 5)]
        [TestCase(new [] {4,5,6,7,0,1,2}, 4, 0)]
        public void Test(int[] nums, int target, int expected)
        {
            var result = Search(nums, target);
            result.Should().Be(expected);
        }

        private int Search(int[] nums, int target)
        {
            var low = 0;
            var high = nums.Length - 1;
            
            while (low < high)
            {
                if (nums[low] == target) return low;
                if (nums[high] == target) return high;

                var middle = (low + high) / 2;
                if (nums[middle] == target) return middle;

                if (nums[middle] > nums[middle - 1])
                {
                    
                }
            }

            return -1;
        }
    }
}