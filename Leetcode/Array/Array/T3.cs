using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * 3. Longest Substring Without Repeating Characters
     */
    public class T3
    {
        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase("dvdf", 3)]
        [TestCase("asjrgapa", 6)]
        public void Test(string s, int output)
        {
            var max = 0;
            var i = 0;
            var j = 0;

            var set = new HashSet<char>();
            while (i < s.Length && j < s.Length)
            {
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j]);
                    j++;
                    max = Math.Max(max, j - i);
                }
                else
                {
                    set.Remove(s[i]);
                    i++;
                }
            }

            max.Should().Be(output);
        }
    }
}