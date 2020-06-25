using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T22
    {
        [TestCase(3, new [] {"((()))", "(()())", "(())()", "()(())", "()()()"})]
        public void Test(int count, string[] output)
        {
            var result = new HashSet<string>();

            Dfs(0, "(", result, count);

            result.Should().BeEquivalentTo(output);
        }

        private void Dfs(int start, string temp, HashSet<string> result, int k)
        {
            if (temp.Length == k * 2)
            {
                result.Add(new string(temp));
            }
            else
            {
                for (var i = start; i < k * 2 - 1; i++)
                {
                    
                }
            }
        }
    }
}