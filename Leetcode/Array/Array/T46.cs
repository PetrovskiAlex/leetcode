using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T46
    {
        [TestCase(new []{1, 2, 3})]
        public void PermuteTest(int[] nums) {
            var result = new List<List<int>>();

            var permute = Permute(nums);

            result.Count.Should().Be(Factorial(nums.Length));
        }

        public List<List<int>> Permute(int[] nums) {
            var list = new List<List<int>>();
            // Arrays.sort(nums); // not necessary
            Backtrack(list, new List<int>(), nums);
            return list;
        }

        private void Backtrack(List<List<int>> list, List<int> tempList, int [] nums){
            if(tempList.Count == nums.Length){
                list.Add(new List<int>(tempList));
            } else{
                for(int i = 0; i < nums.Length; i++){ 
                    if(tempList.Contains(nums[i])) continue; // element already exists, skip
                    tempList.Add(nums[i]);
                    Backtrack(list, tempList, nums);
                    tempList.Remove(tempList.Count - 1);
                }
            }
        } 
        
        private int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
    }
}