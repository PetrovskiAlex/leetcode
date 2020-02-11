using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T1
    {
        [TestCase(new []{2, 7, 11, 15}, 9, new []{0 ,1})]
        [TestCase(new []{3, 2, 4}, 6, new []{1, 2})]
        [TestCase(new []{3, 3}, 6, new []{0, 1})]
        public void Test(int[] array, int target, int[] result)
        {
            var map = new Dictionary<int, int>();

            var r = new int[2];
            for (int i = 0; i < array.Length; i++)
            {
                var el = array[i];
                if (map.ContainsKey(target - el))
                {
                    r[0] = map[target - el];
                    r[1] = i;
                    break;
                }
                else
                {
                    map[el] = i;
                }
            }

            r.Should().Equal(result);
        }
    }
}