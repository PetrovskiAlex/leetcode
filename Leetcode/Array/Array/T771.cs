using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T771
    {
        [TestCase("aA", "aAAbbbb", 3)]
        [TestCase("z", "ZZ", 0)]
        public void Test(string j, string s, int output)
        {
            var map = new Dictionary<char, int>();
            foreach (var c in j)
            {
                map[c] = 0;
            }

            var result = s.Count(c => map.ContainsKey(c));

            result.Should().Be(output);
        }
    }
}