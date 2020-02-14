using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T283
    {
        [TestCase(new [] {0,1,0,3,12}, new [] {1,3,12,0,0})]
        public void Test(int[] input, int[] output)
        {
            var j = input.Length;
            for (var i = 0; i < j; i++)
            {
                if (input[i] == 0)
                {
                    while (j > i && input[j - 1] == 0)
                    {
                        j--;
                    }

                    if (i >= j)
                    {
                        break;
                    }
                    else
                    {
                        input[i] = input[j - 1];
                        input[j - 1] = 0;
                    }
                }
            }

            input.Should().Equal(output);
        }
    }
}