using System.Collections.Generic;
using NUnit.Framework;

namespace Backtracking
{
    public class T77
    {
        [TestCase(4,2)]
        public void Test(int numbers, int k)
        {
            var elements = new List<int>();
            for (var i = 1; i <= numbers; i++)
            {
                elements.Add(i);
            }
            
            var result = new List<List<int>>();
            Dfs(0, elements, new List<int>(), result, k);
        }
        
        private void Dfs(int start, List<int> input, List<int> temp, List<List<int>> result, int k)
        {
            if (temp.Count == k)
            {
                result.Add(new List<int>(temp));    
            }

            for (var i = start; i < input.Count; i++)
            {
                temp.Add(input[i]);
                Dfs(i + 1, input, temp, result, k);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}