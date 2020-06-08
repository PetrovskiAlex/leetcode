using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T39
    {
        [TestCase(new [] {2,3,5}, 8, 3)]
        [TestCase(new [] {2,3,6,7}, 7, 2)]
        [TestCase(new [] {1}, 1, 1)]
        public void Test(int[] array, int target, int output)
        {
            var result = new List<IList<int>>();

            for (int i = 0; i < array.Length; i++)
            {
                var accumulator = new List<List<int>>
                {
                    new List<int>{array[i], target - array[i]}
                };
                while (accumulator.Any())
                {
                    var newAccimulator = new List<List<int>>();
                    for (var k = i; k < array.Length; k++)
                    {
                        for (var j = 0; j < accumulator.Count; j++)
                        {
                            var sub = accumulator[j];
                            if (sub[sub.Count - 1] == 0)
                            {
                                result.Add(sub);
                                continue;
                            }
                            
                            var el = array[k];
                            if (sub[sub.Count - 1] - el == 0)
                            {
                                result.Add(sub);
                            }
                            else if (sub[sub.Count - 1] - el > 0)
                            {
                                var newArray = new List<int>(sub);
                                
                                var lastEl = newArray[newArray.Count - 1];
                                newArray.RemoveAt(newArray.Count - 1);
                                newArray.Add(el);
                                newArray.Add(lastEl - el);
                                
                                newAccimulator.Add(newArray);
                            }
                        }
                    }

                    accumulator = newAccimulator;
                }
            }

            result.All(r => r.Sum() == target).Should().BeTrue();
            result.Count.Should().Be(output);
        }
    }
}