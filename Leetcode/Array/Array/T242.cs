using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T242
    {
        [TestCase("anagramz", "nagaramz", true)]
        [TestCase("rat", "car", false)]
        public void Test(string s, string t, bool output)
        {
            var array = new int[26];
            foreach (var c in s)
            {
                array[c - 'a']++;
            }

            foreach (var c in t)
            {
                array[c - 'a']--;
            }

            var result = array.All(a => a == 0);

            result.Should().Be(output);
        }
    }
}