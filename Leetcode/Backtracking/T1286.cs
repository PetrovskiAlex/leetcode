using System.Collections.Generic;
using NUnit.Framework;

namespace Backtracking
{
    public class T1286
    {
        [TestCase("abc", 2)]
        public void Test(string characters, int length)
        {
            var combinations = GetCombinations(characters, length);
        }

        private Queue<string> GetCombinations(string characters, int length)
        {
            var result = new Queue<string>();
            Dfs(0, characters, "", result, length);
            return result;
        }

        private void Dfs(int start, string characters, string temp, Queue<string> result, int count)
        {
            if (temp.Length == count)
            {
                result.Enqueue(temp);
            }
            else
            {
                for (var i = start; i < characters.Length; i++)
                {
                    temp += characters[i];
                    Dfs(i + 1, characters, temp, result, count);
                    temp = temp.Remove(temp.Length - 1);
                }
            }
        }
    }
}