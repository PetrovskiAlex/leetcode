using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T448
    {
        /*
         * 448. Find All Numbers Disappeared in an Array
         */
        [TestCase(new []{4,3,2,7,8,2,3,1}, new [] {5,6})]
        [TestCase(new []{1,1,1}, new [] {2,3})]
        public void Test(int[] nums, int[] output)
        {
            if (!nums.Any()) return;
            
            var result = new List<int>();

            
            result.Should().BeEquivalentTo(output);
        }
    }
}