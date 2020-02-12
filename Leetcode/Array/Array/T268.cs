using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T268
    {
        
        [TestCase(new [] {3,0,1}, 2)]
        [TestCase(new [] {9,6,4,2,3,5,7,0,1}, 8)]
        public void Test(int[] nums, int result)
        {
            var current = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                current ^= i ^ nums[i];
            }

            current.Should().Be(result);
        }
        
        [TestCase(new [] {3,0,1}, 2)]
        [TestCase(new [] {9,6,4,2,3,5,7,0,1}, 8)]
        public void TestGauss(int[] nums, int result)
        {
            var exptectedSum = nums.Length * (nums.Length + 1) / 2;
            var actualResult = exptectedSum - nums.Sum();

            actualResult.Should().Be(result);
        }
    }
}