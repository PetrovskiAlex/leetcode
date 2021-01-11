using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /// <summary>
    /// Find Common Characters
    ///
    /// Given an array A of strings made only from lowercase letters, return a list of all characters that show up in all strings within the list (including duplicates).  For example, if a character occurs 3 times in all strings but not 4 times, you need to include that character three times in the final answer.
    /// </summary>
    public class T1002
    {
        [TestCase(new [] {"bella","label","roller"}, new [] {"e","l","l"})]
        [TestCase(new [] {"bella","labe","roller"}, new [] {"e","l"})]
        [TestCase(new [] {"cool","lock","cook"}, new [] {"c","o"})]
        [TestCase(new [] {"acabcddd","bcbdbcbd","baddbadb","cbdddcac","aacbcccd","ccccddda","cababaab","addcaccd"}, new string[0])]
        public void Test(string[] input, string[] output)
        {
            var result = new List<string>();

            var chars = new int[27];
            var current = new int[27];

            for (var index = 0; index < input.Length; index++)
            {
                if (index == 0)
                {
                    var s = input[index];
                    foreach (var c in s)
                    {
                        chars[c - 97]++;
                    }    
                }
                else
                {
                    var s = input[index];
                    foreach (var c in s)
                    {
                        current[c - 97]++;
                    }

                    for (var i = 0; i < chars.Length; i++)
                    {
                        chars[i] = Math.Min(chars[i], current[i]);
                        current[i] = 0;
                    }
                }
            }

            for (var index = 0; index < chars.Length; index++)
            {
                var c = chars[index];
                if (c == 0) continue;

                for (var i = 0; i < c; i++)
                {
                    result.Add(((char) (index + 97)).ToString());    
                }
            }

            result.Should().Equal(output);
        }
    }
}