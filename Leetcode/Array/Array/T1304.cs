using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T1304
    {
        [TestCase(5)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(1)]
        public void Test(int n)
        {
            var array = Generate(n);

            array.Sum().Should().Be(0);
            array.Length.Should().Be(n);
        }

        private int[] Generate(int n)
        {
            if (n <= 1) return new[] {0};

            var random = new Random(1);

            var result = new List<int>();
            if (n % 2 == 0)
            {
                for (int var = 0; var < n / 2; var++)
                {
                    var element = random.Next(5000);
                    result.Add(element);
                    result.Add(-element);    
                }
            }
            else
            {
                for (int var = 0; var < (n - 1) / 2; var++)
                {
                    var element = random.Next(5000);
                    result.Add(element);
                    result.Add(-element);    
                }
                
                result.Add(0);
            }


            return result.ToArray();
        }
    }
}