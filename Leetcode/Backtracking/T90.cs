using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T90
    {
        [Test]
        public void Test()
        {
            var numbers = new [] { 1,2,2 };
            var result = new List<List<int>>();
            Array.Sort(numbers);

            Dfs(0, numbers, new List<int>(), result);

            result = result.OrderBy(r => r.Count).ToList();
            
            result.Count.Should().Be(6);
        }

        private void Dfs(int start, int[] nums, List<int> temp, List<List<int>> result)
        {
            result.Add(new List<int>(temp));
            for (var i = start; i < nums.Length; i++)
            {
                if (i == start || nums[i] != nums[i - 1])
                {
                    temp.Add(nums[i]);
                    Dfs(i + 1, nums, temp, result);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }
    }
}