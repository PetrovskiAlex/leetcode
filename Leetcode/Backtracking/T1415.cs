using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T1415
    {
        private string _result = "";

        [TestCase(3, 9, "cab")]
        [TestCase(1, 3, "c")]
        [TestCase(1, 4, "")]
        [TestCase(2, 7, "")]
        [TestCase(10, 100, "abacbabacb")]
        public void Test(int letters, int k, string output)
        {
            var array = new []{'a', 'b', 'c'};

            var result = new List<string>();
            Dfs(0, "", result, array, letters);

            var strResult = result.Count < k ? "" : result[k - 1];
            strResult.Should().Be(output);
        }

        private void Dfs(int start, string temp, List<string> result, char[] letters, int k)
        {
            if (temp.Length == k)
            {
                result.Add(temp);
            }
            else
            {
                for (var i = start; i < letters.Length; i++)
                {
                    if (temp.Length == 0 || temp[temp.Length - 1] != letters[i])
                    {
                        temp += letters[i];
                        Dfs(start, temp, result, letters, k);
                        temp = temp.Remove(temp.Length - 1);
                    }
                }
            }
        }
    }
}