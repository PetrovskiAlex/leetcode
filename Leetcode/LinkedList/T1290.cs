using System;
using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    /*
     * 1290. Convert Binary Number in a Linked List to Integer
     */
    public class T1290 : BaseLinkedListTest
    {
        [TestCase(new [] {1,0,1}, 5)]
        [TestCase(new [] {0}, 0)]
        [TestCase(new [] {0,0}, 0)]
        [TestCase(new [] {1}, 1)]
        [TestCase(new [] {1,0,0,1,0,0,1,1,1,0,0,0,0,0,0}, 18880)]
        public void Test(int[] input, int ouput)
        {
            var node = CreateLinkedList(input);
            var head = node;

            var count = 0;
            while (node.next != null)
            {
                count++;
                node = node.next;
            }

            var result = 0;
            while (head != null)
            {
                result += ((int) Math.Pow(2, count--) * head.val);
                head = head.next;
            }

            result.Should().Be(ouput);
        }
    }
}