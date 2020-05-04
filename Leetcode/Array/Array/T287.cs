using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * Find the Duplicate Number
     * Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.
     */
    public class T287
    {
        [TestCase(new[]{1,3,4,2,2}, 2)]
        [TestCase(new[]{3,1,3,4,2}, 3)]
        public void FindDuplicate(int[] nums, int result)
        {
            FindDuplicateHareTortoise(nums);
            FindDuplicateInner(nums).Should().Be(result);
        }

        private int FindDuplicateInner(int[] nums)
        {
            System.Array.Sort(nums);
            
            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1]) return nums[i];
            }

            return -1;
        }
        
        public int FindDuplicateHareTortoise(int[] nums) {
            // Find the intersection point of the two runners.
            int tortoise = nums[0];
            int hare = nums[0];
            do {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (tortoise != hare);

            // Find the "entrance" to the cycle.
            tortoise = nums[0];
            while (tortoise != hare) {
                tortoise = nums[tortoise];
                hare = nums[hare];
            }

            return hare;
        }
    }
}