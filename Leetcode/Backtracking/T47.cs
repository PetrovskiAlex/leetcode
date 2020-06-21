using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T47
    {
        [TestCase(new [] {1,1,2})]
        public void Test(int[] nums)
        {
            var result = new List<IList<int>>();

            Dfs(nums, new List<int>(), result, new bool[nums.Length]);
        }
        
        private void Dfs(int[] input, List<int> temp, List<IList<int>> result, bool[] used)
        {
            if (temp.Count == input.Length)
            {
                result.Add(new List<int>(temp));    
            }

            for (var i = 0; i < input.Length; i++)
            {
                if (used[i] || i > 0 && input[i] == input[i-1] && !used[i - 1]) continue;

                temp.Add(input[i]);
                used[i] = true;
                Dfs(input, temp, result, used);
                used[i] = false;
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}