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
            for (int i = 0; i < s.Length; i++)
            {
                var subMax = GetMaxSubstring(s.Substring(i, s.Length - i));
                max = Math.Max(max, subMax);
            }

            max.Should().Be(output);
        }

        private static int GetMaxSubstring(string s)
        {
            var result = 0;

            var set = new HashSet<char>();
            foreach (var c in s)
            {
                if (set.Contains(c))
                {
                    set = new HashSet<char> {c};
                }
                else
                {
                    set.Add(c);
                    if (result < set.Count)
                    {
                        result = set.Count;
                    }
                }
            }

            return result;
        }
    }
}