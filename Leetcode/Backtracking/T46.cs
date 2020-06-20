using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T46
    {
        [TestCase(new[] {1, 2, 3})]
        [TestCase(new[] {1, 2, 3, 4})]
        [TestCase(new[] {1, 2, 3, 4, 5})]
        public void PermuteTest(int[] nums)
        {
            var result = new List<IList<int>>();

            Permute(nums, result);

            result.Count.Should().Be(Factorial(nums.Length));
        }

        [TestCase(new[] {1, 2, 3})]
        [TestCase(new[] {1, 2, 3, 4})]
        [TestCase(new[] {1, 2, 3, 4, 5})]
        public void PermuteBacktrackTest(int[] nums)
        {
            var result = new List<IList<int>>();

            Dfs(nums, new List<int>(), result);

            result.Count.Should().Be(Factorial(nums.Length));
        }
        
        private void Dfs(int[] input, List<int> temp, List<IList<int>> result)
        {
            if (temp.Count == input.Length)
            {
                result.Add(new List<int>(temp));    
            }

            for (var i = 0; i < input.Length; i++)
            {
                if(temp.Contains(input[i])) continue;

                temp.Add(input[i]);
                Dfs(input, temp, result);
                temp.RemoveAt(temp.Count - 1);
            }
        }
        
        private IList<IList<int>> Permute(int[] nums, List<IList<int>> result)
        {
            if (nums == null) return null;
            if (nums.Length == 1) return new List<IList<int>>{new List<int>{nums[0]}};
            if (nums.Length == 2) return new List<IList<int>>{new List<int>(nums), new List<int>(nums.Reverse())};
            
            for (var i = 0; i < nums.Length; i++)
            {
                var temp = nums[0];
                nums[0] = nums[i];
                nums[i] = temp;

                var permutations = Permute(SubArray(nums, 1));
                foreach (var permutation in permutations)
                {
                    permutation.Insert(0, nums[0]);
                    result.Add(permutation);
                }
            }

            return result;
        }

        private List<List<int>> Permute(int[] nums)
        {
            if (nums == null) return null;
            if (nums.Length == 1) return new List<List<int>>{new List<int>{nums[0]}};
            if (nums.Length == 2) return new List<List<int>>{new List<int>(nums), new List<int>(nums.Reverse())};
            
            var result = new List<List<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                var temp = nums[0];
                nums[0] = nums[i];
                nums[i] = temp;

                var permutations = Permute(SubArray(nums, 1));
                foreach (var permutation in permutations)
                {
                    permutation.Insert(0, nums[0]);
                    result.Add(permutation);
                }
            }

            return result;
        }
        
        private static int[] SubArray(int[] data, int index)
        {
            var result = new int[data.Length - index];
            System.Array.Copy(data, index, result, 0, data.Length - index);
            return result;
        }
        
        private int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
    }
}