using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T119
    {

        [TestCase(3, new []{1,3,3,1})]
        [TestCase(4, new []{1,4,6,4,1})]
        public void Test(int n, int[] result)
        {
            var list = new List<int>();

            var count = n - 1;
            for (var i = 0; i < n+1; i++)
            {
                var ints = new List<int>();
                for (var j = 0; j < n - count; j++)
                {
                    if (j == 0 || j == n - count - 1)
                    {
                        ints.Add(1);
                    }
                    else
                    {
                        ints.Add(list[j-1] + list[j]);
                    }
                }

                list = ints;

                count--;
            }

            list.Should().Equal(result);
        }
    }
}