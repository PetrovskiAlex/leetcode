using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * 49. Group Anagrams
     */
    public class T49
    {
        [Test]
        public void Test()
        {
            var array = new[] {"eat", "tea", "tan", "ate", "nat", "bat"};
            var output = new List<IList<string>>
            {
                new List<string>{"ate","eat","tea"},
                new List<string>{"nat","tan"},
                new List<string>{"bat"}
            };
            
            var mapResult = new Dictionary<string, IList<string>>();

            foreach (var s in array)
            {
                var chars = s.ToCharArray();
                System.Array.Sort(chars);
                var newString = new string(chars);
                
                if (mapResult.ContainsKey(newString))
                {
                    mapResult[newString].Add(s);
                }
                else
                {
                    mapResult[newString] = new List<string>{s};
                }
            }

            var result = mapResult.Select(kv => kv.Value).ToList();

            result.Should().BeEquivalentTo(output);
        }
    }
}