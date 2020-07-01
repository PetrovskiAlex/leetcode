using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Backtracking
{
    public class T1291
    {
        [TestCase(100, 300, new[] {123, 234})]
        [TestCase(58, 155, new[] {67,78,89,123})]
        [TestCase(10, 1000000000, new[]
        {
            12,23,34,45,56,67,78,89,
            123, 234, 345, 456, 567, 678, 789, 1234, 2345, 3456, 4567, 5678, 6789, 12345,
            23456, 34567, 45678, 56789, 123456, 234567, 345678, 456789, 1234567, 2345678, 3456789, 12345678, 23456789,
            123456789
        })]
        [TestCase(1000, 13000, new[] {1234, 2345, 3456, 4567, 5678, 6789, 12345})]
        public void Test(int low, int high, int[] output)
        {
            var result = new List<int>();
            for (var digit = 1; digit < 9; ++digit)
            {
                int next = digit, n = next;
                while (n <= high && next < 10)
                {
                    if (n >= low)
                    {
                        result.Add(n);
                    }

                    int n1 = n * 10 + ++next;
                    if (n1 > n)
                    {
                        n = n1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            result.Sort();

            result.Should().BeEquivalentTo(output);
        }
    }
}