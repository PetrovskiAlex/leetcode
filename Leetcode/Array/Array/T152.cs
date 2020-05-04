using System;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T152
    {
        [TestCase(new []{2,3,-2,4}, 6)]
        [TestCase(new []{-2,0,-1}, 0)]
        [TestCase(new []{-2,3,5,-4}, 120)]
        [TestCase(new []{-4,-3,-2}, 12)]
        public void Test(int[] nums, int result)
        {
            var maxProduct = GetMaxProduct(nums);

            maxProduct.Should().Be(result);
        }

        private static int GetMaxProduct(int[] nums)
        {
            if (nums.Length < 1) return -1;

            var product = 0;
            var maxProduct = nums[0];
            var minProduct = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                var num = nums[i];
                var temp = maxProduct;
                maxProduct = Math.Max(num, Math.Max(maxProduct * num, minProduct * num));
                minProduct = Math.Min(num, Math.Min(num * minProduct, num * temp));

                if (maxProduct > product)
                {
                    product = maxProduct;
                }
            }

            return product;
        }
    }
}