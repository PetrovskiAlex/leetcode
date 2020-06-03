using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T387
    {
        [TestCase("leetcode", 0)]
        [TestCase("loveleetcode", 2)]
        [TestCase("cc", -1)]
        public void Test(string s, int index)
        {
            var array = new int [26];
            
            foreach (var ch in s)
            {
                array[ch - 'a']++;
            }

            var result = -1;
            for (var i = 0; i < s.Length; i++)
            {
                if (array[s[i] - 'a'] == 1)
                {
                    result = i;
                    break;
                }
            }

            result.Should().Be(index);
        }
    }
}