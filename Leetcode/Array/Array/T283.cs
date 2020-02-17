using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T283
    {
        [TestCase(new [] {0,1,0,3,12}, new [] {1,3,12,0,0})]
        [TestCase(new [] {0, 0, 0, 0}, new [] {0, 0, 0, 0})]
        [TestCase(new [] {0, 0, 0, 0, 1}, new [] {1, 0, 0, 0, 0})]
        [TestCase(new [] {0, 0, -27}, new [] {-27, 0, 0})]
        [TestCase(new [] {1, 1, 0}, new [] {1, 1, 0})]
        public void Test(int[] input, int[] output)
        {
            var currentZero = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] != 0)
                {
                    var temp = input[currentZero]; 
                    input[currentZero] = input[i];
                    input[i] = temp;
                    currentZero++;
                }
            }

            input.Should().Equal(output);
        }
    }
}