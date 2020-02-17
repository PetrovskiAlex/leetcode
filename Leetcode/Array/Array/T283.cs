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
        public void Test(int[] input, int[] output)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == 0)
                {
                    var nonZeroIndex = FindNonZeroIndex(input, i + 1);
                    if (nonZeroIndex > -1)
                    {
                        input[i] = input[nonZeroIndex];
                        input[nonZeroIndex] = 0;    
                    }
                    else
                    {
                        break;
                    }
                }
            }

            input.Should().Equal(output);
        }

        private int FindNonZeroIndex(int[] array, int startIndex)
        {
            for (var i = startIndex; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}