using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T189
    {
        [TestCase(new []{1,2,3,4,5,6,7}, new [] {5,6,7,1,2,3,4}, 3)]
        public void Test(int[] input, int[] output, int k)
        {
            k %= input.Length;
            Reverse(input, 0, input.Length - 1);
            Reverse(input, 0, k - 1);
            Reverse(input, k, input.Length - 1);

            input.Should().Equal(output);
        }

        private void Reverse(int[] input, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                var temp = input[startIndex];
                input[startIndex] = input[endIndex];
                input[endIndex] = temp;

                startIndex++;
                endIndex--;
            }
        }
    }
}