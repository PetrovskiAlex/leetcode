using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * Given an array nums of integers, return how many of them contain an even number of digits.
 

Example 1:

Input: nums = [12,345,2,6,7896]
Output: 2
Explanation: 
12 contains 2 digits (even number of digits). 
345 contains 3 digits (odd number of digits). 
2 contains 1 digit (odd number of digits). 
6 contains 1 digit (odd number of digits). 
7896 contains 4 digits (even number of digits). 
Therefore only 12 and 7896 contain an even number of digits.
Example 2:

Input: nums = [555,901,482,1771]
Output: 1 
Explanation: 
Only 1771 contains an even number of digits.
     */
    
    public class T1295
    {
        [TestCase(new []{12, 345, 2, 6, 7896}, 2)]
        [TestCase(new []{555,901,482,1771}, 1)]
        [TestCase(new []{555,901,482,17712}, 0)]
        [TestCase(new []{580,317,640,957,718,764}, 0)]

        public void Test(int[] array, int count)
        {
            var result = 0;
            foreach (var t in array)
            {
                var element = t;
                var length = 0;
                while (element > 0 || element % 10 > 0)
                {
                    element /= 10;
                    length++;
                }

                if (length % 2 == 0)
                {
                    result++;
                }
            }

            result.Should().Be(count);
        }
    }
}