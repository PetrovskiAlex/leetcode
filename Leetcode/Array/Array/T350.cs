using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /// <summary>
    /// Intersection of Two Arrays II
    /// arrays, write a function to compute their intersection.
    /// </summary>
    public class T350
    {
        [TestCase(new [] {1,2,2,1}, new [] {2,2}, new [] {2,2})]
        [TestCase(new [] {4,9,5}, new [] {9,4,9,8,4}, new [] {4,9})]
        public void Test(int[] input1, int[] input2, int[] output)
        {
            var map1 = new Dictionary<int, int>();
            var map2 = new Dictionary<int, int>();
            var result = new List<int>();

            foreach (var i in input1)
            {
                if (map1.ContainsKey(i))
                {
                    map1[i]++;
                }
                else
                {
                    map1[i] = 1;
                }
            }

            foreach (var i in input2)
            {
                if (map2.ContainsKey(i))
                {
                    map2[i]++;
                }
                else
                {
                    map2[i] = 1;
                }
            }

            foreach (var kv in map1)
            {
                var valueInMap2 = map2.GetValueOrDefault(kv.Key);
                var max = Math.Min(kv.Value, valueInMap2);
                for (int i = 0; i < max; i++)
                {
                    result.Add(kv.Key);
                }
            }

            result.ToArray().Should().Equal(output);
        }
    }
}