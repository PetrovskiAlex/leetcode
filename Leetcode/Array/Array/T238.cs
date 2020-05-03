using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T238
    {
        [TestCase(new[] {1, 2, 3, 4}, new []{24,12,8,6})]
        [TestCase(new[] {1,2,3,0,5,0}, new []{0,0,0,0,0,0})]
        [TestCase(new[] {1,2,3,0,5}, new []{0,0,0,30,0})]
        public void ProductExceptSelfTest(int[] nums, int[] output)
        {
            var result = GetProduct(nums);

            result.Should().Equal(output);
        }

        private static int[] GetProduct(int[] nums)
        {
            var length = nums.Length;

            var result = new int[length];

            result[0] = 1;
            for (var i = 1; i < length; i++) {

                result[i] = nums[i - 1] * result[i - 1];
            }

            var x = 1;
            for (var i = length - 1; i >= 0; i--)
            {
                result[i] = result[i] * x;
                x *= nums[i];
            }

            return result;
        }
    }
}