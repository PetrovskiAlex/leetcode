using System.Collections.Generic;
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

            Dfs(0, 0, "", result, count);

            result.Should().BeEquivalentTo(output);
        }

        private void Dfs(int opened, int closed, string temp, HashSet<string> result, int k)
        {
            if (temp.Length == k * 2)
            {
                result.Add(new string(temp));
            }
            else
            {
                if (opened < k)
                {
                    Dfs(opened + 1, closed, temp + "(", result, k);
                }

                if (closed < opened)
                {
                    Dfs(opened, closed + 1, temp + ")", result, k);
                }
            }
        }
    }
}