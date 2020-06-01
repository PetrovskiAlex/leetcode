using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T347
    {
        [TestCase(new [] {3,2,1,2,1,2,1,2}, 1, new [] {2})]
        [TestCase(new [] {3,2,1,2,1,2,1}, 2, new [] {1,2})]
        [TestCase(new [] {1}, 1, new [] {1})]
        public void Test(int[] input, int frequent, int[] output)
        {
            var map = new Dictionary<int, HashSet<int>>();
            var frequency = new Dictionary<int, int>();

            var maxCount = int.MinValue;

            foreach (var el in input)
            {
                frequency[el] = frequency.GetValueOrDefault(el) + 1;

                if (frequency[el] > maxCount)
                {
                    maxCount = frequency[el];
                }
            }

            foreach (var kv in frequency)
            {
                if (map.ContainsKey(kv.Value))
                {
                    map[kv.Value].Add(kv.Key);
                }
                else
                {
                    map[kv.Value] = new HashSet<int>{kv.Key};
                }
            }

            var result = new List<int>();
            while (frequent > 0)
            {
                if (map.ContainsKey(maxCount))
                {
                    var numbers = map[maxCount].ToArray();
                    result.AddRange(numbers);
                    maxCount--;
                    frequent -= numbers.Length;
                }
                else
                {
                    maxCount--;
                }
            }

            result.Should().BeEquivalentTo(output);
        }
    }
}