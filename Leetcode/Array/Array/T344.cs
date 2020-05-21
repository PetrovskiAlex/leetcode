using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T344
    {
        [TestCase(new []{'h','e','l','l','o'}, new [] {'o','l','l','e','h'})]
        public void Test(char[] s, char[] result)
        {
            var low = 0;
            var high = s.Length - 1;

            while (low < high)
            {
                var temp = s[low];
                s[low] = s[high];
                s[high] = temp;

                low++;
                high--;
            }

            s.Should().BeEquivalentTo(result);
        }
    }
}