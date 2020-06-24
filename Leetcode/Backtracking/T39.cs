using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Backtracking
{
    public class T39
    {
        [TestCase(new[]{2,3,6,7}, 7)]
        public void Test(int[] nums, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            Dfs(0, nums, new List<int>(), result, target);
        }

        private void Dfs(int start, int[] nums, List<int> temp, List<IList<int>> result, int target)
        {
            if (temp.Sum() == target)
            {
                result.Add(new List<int>(temp));
                return;
            }

            for (var i = start; i < nums.Length; i++)
            {
                var currentSum = temp.Sum();
                if (currentSum + nums[i] <= target)
                {
                    temp.Add(nums[i]);
                    Dfs(i, nums, temp, result, target);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }
    }
}