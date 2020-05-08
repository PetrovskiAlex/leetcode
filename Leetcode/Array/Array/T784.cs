using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * 784. Letter Case Permutation
     * Given a string S, we can transform every letter individually to be lowercase or uppercase to create another string.  Return a list of all possible strings we could create.
     */
    public class T784
    {
        [TestCase("a1b2", new []{"a1b2", "a1B2", "A1b2", "A1B2"})]
        [TestCase("a1by", new []{"a1by","a1bY","a1By","a1BY","A1by","A1bY","A1By","A1BY"})]
        [TestCase("3z4", new []{"3z4", "3Z4"})]
        [TestCase("12345", new []{"12345"})]
        public void Test(string s, string[] output)
        {
            var count = s.Count(char.IsLetter);

            var resultAmount = (int) Math.Pow(2, count);
            var result = new List<char[]>(resultAmount);
            if (count == 0) return;

            for (var i = 0; i < resultAmount; i++)
            {
                result.Add(new char[s.Length]);
            }

            var delimeter = resultAmount / 2;
            for (var i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    var current = char.ToLower(s[i]);
                    var index = 0;
                    for (var k = 0; k < resultAmount; k += delimeter)
                    {
                        var j = delimeter;
                        while (j > 0)
                        {
                            result[index++][i] = current;
                            j--;
                        }

                        current = char.IsLower(current) 
                            ? char.ToUpper(current) 
                            : char.ToLower(current);
                    }

                    delimeter = Math.Max(delimeter / 2, 1);
                }
                else
                {
                    for (var j = 0; j < resultAmount; j++)
                    {
                        result[j][i] = s[i];
                    }
                }
            }

            result.Select(c => new string(c)).Should().Equal(output);
        }
    }
}