using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T1079
    {
        [TestCase("AAB", 8)]
        [TestCase("AAABBC", 188)]
        public void Test(string tiles, int output)
        {
            var chars = tiles.ToCharArray();
            Array.Sort(chars);
            var newTiles = new string(chars);

            var result = 0; 
            var used = new bool[chars.Length];
            Dfs(newTiles, new List<string>(), ref result, used);

            result.Should().Be(output);
        }
        
        private void Dfs(string input, List<string> temp, ref int result, bool[] used)
        {
            if (temp.Count > 0)
            {
                result++;
            }

            for (var i = 0; i < input.Length; i++)
            {
                if (used[i] || i > 0 && input[i] == input[i-1] && !used[i - 1]) continue;

                temp.Add(input[i].ToString());
                used[i] = true;
                Dfs(input, temp, ref result, used);
                used[i] = false;
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}