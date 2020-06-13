using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T1470
    {
        [TestCase(new [] {2,5,1,3,4,7}, new [] {2,3,5,4,1,7}, 3)]
        [TestCase(new [] {1,2,3,4,4,3,2,1}, new [] {1,4,2,3,3,2,4,1}, 4)]
        public void Test(int[] input, int[] output, int n)
        {
            var newArray = new int[input.Length];
            var index = 0;
            
            for (var i = 0; i < input.Length / 2; i++)
            {
                newArray[index] = input[i];
                newArray[index + 1] = input[i + n];

                index += 2;
            }

            newArray.Should().BeEquivalentTo(output);
        }
    }
}