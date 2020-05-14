using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T78
    {
        [TestCase(new []{1,2,3})]
        [TestCase(new []{1,2,3,4})]
        public void Test(int[] input)
        {
            var result = new List<List<int>>();

            foreach (var i in input)
            {
                var subResult = new List<List<int>>();
                foreach (var list in result)
                {
                    var ints = new List<int>(list) {i};
                    subResult.Add(ints);
                }

                result.AddRange(subResult);
                result.Add(new List<int>{i});
            }

            result.Add(new List<int>());
            result.Count.Should().Be((int)Math.Pow(2, input.Length));
        }

        [TestCase(new []{1,2,3})]
        [TestCase(new []{1,2,3,4})]
        public void TestBackTrack(int[] nums)
        {
            var list = subsets(nums);
            
            list.Count.Should().Be((int)Math.Pow(2, nums.Length));
        }
        
        List<List<int>> output = new List<List<int>>();
        int n, k;

        public void backtrack(int first, List<int> curr, int[] nums) {
            // if the combination is done
            if (curr.Count == k)
                output.Add(new List<int>(curr));

            for (int i = first; i < n; ++i) {
                // add i into the current combination
                curr.Add(nums[i]);
                // use next integers to complete the combination
                backtrack(i + 1, curr, nums);
                // backtrack
                curr.RemoveAt(curr.Count - 1);
            }
        }

        public List<List<int>> subsets(int[] nums) {
            n = nums.Length;
            for (k = 0; k < n + 1; ++k) {
                backtrack(0, new List<int>(), nums);
            }
            return output;
        }
        
    }
}