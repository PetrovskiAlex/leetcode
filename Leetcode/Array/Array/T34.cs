using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T34
    {
        
        /*
         * 34. Find First and Last Position of Element in Sorted Array
         * Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.

            Your algorithm's runtime complexity must be in the order of O(log n).
         */
        [TestCase(new []{5,7,7,8,8,10},  8, new [] {3,4})]
        [TestCase(new []{7,7,7,8,8,10},  7, new [] {0,2})]
        [TestCase(new []{8,8,9,7,7,7},  7, new [] {3,5})]
        [TestCase(new []{5,7,7,8,8,8,8,10},  8, new [] {3,6})]
        [TestCase(new []{1,2,3,4},  8, new [] {-1,-1})]
        [TestCase(new []{1},  1, new [] {0,0})]
        [TestCase(new int[0],  1, new [] {-1,-1})]
        public void Test(int[] nums, int target, int[] output)
        {
            var low = 0;
            var high = nums.Length;
            var result = new List<int>();

            while (low < high)
            {
                var middle = (low + high) / 2;
                if (nums[middle] == target)
                {
                    result = FindRange(nums, middle);
                    break;
                }
                else
                {
                    if (nums[middle] >= target)
                    {
                        high = middle - 1;
                    }
                    else
                    {
                        low = middle + 1;
                    }
                }
            }

            if (!result.Any())
            {
                result = new List<int>{-1, -1};
            }
            
            result.Should().BeEquivalentTo(output);
        }

        private List<int> FindRange(int[] nums, int index)
        {
            var target = nums[index];

            var lowIndex = index;
            while (lowIndex > 0)
            {
                if (nums[lowIndex] != target)
                {
                    break;
                }
                lowIndex--;
            }
            
            if (lowIndex >= 0 && nums[lowIndex] != target)
            {
                lowIndex++;
            }

            var highIndex = index;

            while (highIndex < nums.Length)
            {
                if (nums[highIndex] != target)
                {
                    break;
                }

                highIndex++;
            }

            if (highIndex < nums.Length && nums[highIndex] != target)
            {
                highIndex--;
            }

            if (highIndex == nums.Length)
            {
                highIndex--;
            }
            
            return new List<int>{lowIndex, highIndex};
        }
    }
}