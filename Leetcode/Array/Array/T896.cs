using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    /*
     * An array is monotonic if it is either monotone increasing or monotone decreasing.

An array A is monotone increasing if for all i <= j, A[i] <= A[j].  An array A is monotone decreasing if for all i <= j, A[i] >= A[j].

Return true if and only if the given array A is monotonic.
     */
    public class T896
    {
        [TestCase(new [] {1,2,2,3}, true)]
        [TestCase(new [] {6,5,4,4}, true)]
        [TestCase(new [] {1,3,2}, false)]
        [TestCase(new [] {1,2,4,5}, true)]
        [TestCase(new [] {1,1,1}, true)]
        public void Test(int[] array, bool result)
        {
            IsMonotonic(array).Should().Be(result);
        }

        private bool IsMonotonic(int[] array)
        {
            if (array.Length == 1) return true;

            bool? condition = null;
            
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (condition.HasValue)
                {
                    if (condition.Value)
                    {
                        if (array[i] > array[i + 1])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (array[i] < array[i + 1])
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (array[i] > array[i + 1])
                    {
                        condition = false;
                    }
                    else if(array[i] < array[i + 1])
                    {
                        condition = true;
                    }
                }
            }
            
            return true;
        }
    }
}