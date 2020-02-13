using System.Collections.Generic;
using NUnit.Framework;

namespace Array
{
    public class T118
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void Test(int n)
        {
            var list = new List<List<int>>();

            var count = n - 1;
            for (var i = 0; i < n; i++)
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
                        var prevList = list[i - 1];
                        ints.Add(prevList[j-1] + prevList[j]);
                    }
                }
                list.Add(ints);

                count--;
            }
            
            Assert.True(true);
        }
    }
}