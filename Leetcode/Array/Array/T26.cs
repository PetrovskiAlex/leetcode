using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T26
    {
        [TestCase(new []{1,1,2}, 2)]
        [TestCase(new []{0,0,1,1,1,2,2,3,3,4}, 5)]
        public void Test(int[] nums, int result)
        {
            var length = 0;
            var index = 0;
            int? prev = null;
            for (var i = 0; i < nums.Length; i++)
            {
                if (prev == null)
                {
                    prev = nums[i];
                    index++;
                    length++;
                }
                else
                {
                    if (prev != nums[i])
                    {
                        length++;
                        prev = nums[i];

                        var temp = nums[index];
                        nums[index] = nums[i];
                        nums[i] = temp;
                        index++;
                    }
                }
            }

            length.Should().Be(result);
        }
    }
}