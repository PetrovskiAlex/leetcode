using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Array
{
    public class T66
    {
        [TestCase(new []{1,2,3}, new [] {1,2,4})]
        [TestCase(new []{4,3,2,1}, new [] {4,3,2,2})]
        [TestCase(new []{9, 9}, new [] {1, 0, 0})]
        [TestCase(new []{0, 0}, new [] {0, 1})]
        [TestCase(new []{9,8,7,6,5,4,3,2,1,0}, new [] {9,8,7,6,5,4,3,2,1,1})]
        public void Test(int[] input, int[] output)
        {
            var list = new List<int>();
            bool? flag = false;
            for (var i = input.Length - 1; i >= 0; i--)
            {
                var el = input[i];
                if (el >= 9 && flag.HasValue)
                {
                    list.Add(0);
                    flag = true;
                }
                else
                {
                    list.Add(flag.HasValue ? el + 1 : el);
                    flag = null;
                }
            }

            if (flag == true)
            {
                list.Add(1);
            }

            
            list.Reverse();
            list.Should().Equal(output);
        }
    }
}