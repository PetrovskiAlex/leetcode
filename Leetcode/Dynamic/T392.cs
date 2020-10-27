using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Dynamic
{
    public class T392
    {
        [TestCase("abc", "ahbgdc", true)]
        [TestCase("axc", "ahbgdc", false)]
        [TestCase("acb", "ahbgdc", false)]
        [TestCase("aaaa", "bbaaa", false)]
        [TestCase("bb", "ahbgdc", false)]
        [TestCase("b", "c", false)]
        public void TestIsSubsequence(string s, string t, bool output)
        {
            var result = true;
            
            result.Should().Be(output);
        }
    }
}