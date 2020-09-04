using System;
using FluentAssertions;
using NUnit.Framework;

namespace Dynamic
{
    public class T121
    {
        [TestCase(new [] {7,1,5,3,6,4}, 5)]
        [TestCase(new [] {7,6,4,3,1}, 0)]
        public void MaxProfitTest(int[] prices, int benefit)
        {
            var result = 0;
            var minPrice = int.MaxValue;
            foreach (var price in prices)
            {
                minPrice = Math.Min(minPrice, price);
                result = Math.Max(result, price - minPrice);
            }

            result.Should().Be(benefit);
        }
    }
}