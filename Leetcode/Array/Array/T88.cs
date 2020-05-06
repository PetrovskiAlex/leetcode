using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T88
    {
        /*
         * Merge Sorted Array
         * Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

Note:

The number of elements initialized in nums1 and nums2 are m and n respectively.
You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
         */
        [TestCase(new [] {1,2,3,0,0,0}, new [] {2,5,6}, 3, 3, new [] {1,2,2,3,5,6})]
        [TestCase(new [] {11,12,13,0,0,0}, new [] {2,5,6}, 3, 3, new [] {2,5,6,11,12,13})]
        [TestCase(new [] {1,2,10,0,0,0}, new [] {2,5,6}, 3, 3, new [] {1,2,2,5,6,10})]
        [TestCase(new [] {4,0,0,0,0,0}, new [] {1,2,3,5,6}, 1, 5, new [] {1,2,3,4,5,6})]
        [TestCase(new [] {0}, new []{1}, 0, 1, new [] {1})]
        [TestCase(new [] {1,2,4,5,6,0}, new []{3}, 5, 1, new [] {1,2,3,4,5,6})]
        public void MergeSortedArraysTest(int[] nums1, int[] nums2, int m, int n, int[] result)
        {
            while (m > 0 && n > 0)
            {
                if (nums2[n - 1] > nums1[m - 1])
                {
                    nums1[m + n - 1] = nums2[n - 1];
                    n--;
                }
                else
                {
                    nums1[m + n - 1] = nums1[m - 1];
                    m--;
                }
            }

            while (n > 0)
            {
                nums1[n - 1] = nums2[n - 1];
                n--;
            }

            nums1.Should().Equal(result);
        }
    }
}