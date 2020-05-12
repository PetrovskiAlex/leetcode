using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T75
    {
        [TestCase(new []{2,0,2,1,1,0}, new []{0,0,1,1,2,2})]
        [TestCase(new []{0,0,0}, new []{0,0,0})]
        [TestCase(new []{1,1,1}, new []{1,1,1})]
        [TestCase(new []{2,2,2}, new []{2,2,2})]
        [TestCase(new []{2,2,1,1}, new []{1,1,2,2})]
        [TestCase(new []{1,1,2,2}, new []{1,1,2,2})]
        [TestCase(new []{2,0,1}, new []{0,1,2})]
        [TestCase(new []{1,2,0}, new []{0,1,2})]
        public void Test(int[] input, int[] output)
        {
            var low = 0;
            var high = input.Length - 1;

            var index = 0;
            while (low < high && index <= high)
            {
                if (input[index] == 0)
                {
                    var temp = input[low];
                    input[low] = 0;
                    input[index] = temp;
                    low++;
                }
                else if (input[index] == 2)
                {
                    var temp = input[high];
                    input[high] = 2;
                    input[index] = temp;
                    high--;
                    index--;
                }

                index++;
            }

            input.Should().BeInAscendingOrder();
        }
    }
}