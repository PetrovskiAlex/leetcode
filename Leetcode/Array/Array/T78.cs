using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T78
    {
        [TestCase(new []{1,2,3})]
        [TestCase(new []{1,2,3,4})]
        public void Test(int[] input)
        {
            var result = new List<List<int>>();

            foreach (var i in input)
            {
                var subResult = new List<List<int>>();
                foreach (var list in result)
                {
                    var ints = new List<int>(list) {i};
                    subResult.Add(ints);
                }

                result.AddRange(subResult);
                result.Add(new List<int>{i});
            }

            result.Add(new List<int>());
            result.Count.Should().Be((int)Math.Pow(2, input.Length));
        }
    }
}