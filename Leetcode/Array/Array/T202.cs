using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T202
    {
        [TestCase(19, true)]
        [TestCase(3, false)]
        [TestCase(1, true)]
        public void Test(int number, bool output)
        {
            var set = new HashSet<int>();
            var result = false;

            while (set.Add(number))
            {
                var sum = 0;
                while (number > 0) {
                    var reminder = number %  10;
                    sum += reminder * reminder;
                    number /= 10;
                }
                if (sum == 1)
                {
                    result = true;
                    break;
                }

                number = sum;
            }

            result.Should().Be(output);
        }
    }
}