using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
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
        public void TestBackTrack(int[] input)
        {
            var result = new List<List<int>>();

            Dfs(0, input, new List<int>(), result);

            result = result.OrderBy(r => r.Count).ToList();

            result.Count.Should().Be((int)Math.Pow(2, input.Length));
        }

        private void Dfs(int start, int[] input, List<int> temp, List<List<int>> result)
        {
            result.Add(new List<int>(temp));

            for (var i = start; i < input.Length; i++)
            {
                temp.Add(input[i]);
                Dfs(i + 1, input, temp, result);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}