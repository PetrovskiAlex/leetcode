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
            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    result = Math.Max(result, prices[j] - prices[i]);
                }
            }

            result.Should().Be(benefit);
        }
    }
}