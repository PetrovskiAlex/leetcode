using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    public class T1019 : BaseLinkedListTest
    {
        [TestCase(new [] {2,1,5}, new [] {5,5,0})]
        [TestCase(new [] {2,7,4,3,5}, new [] {7,0,5,5,0})]
        [TestCase(new [] {2}, new [] {0})]
        [TestCase(new [] {2,2}, new [] {0,0})]
        [TestCase(new [] {9,7,6,7,6,9}, new [] {0,9,7,9,9,0})]
        public void Test(int[] input, int[] output)
        {
            var node = CreateLinkedList(input);
            var result = new List<int>();

            while (node != null)
            {
                var nextMax = GetNextMax(node.next, node.val);
                result.Add(nextMax);

                node = node.next;
            }

            result.Should().BeEquivalentTo(output);
            
            int GetNextMax(ListNode n, int current)
            {
                if (n == null)
                {
                    return 0;
                }

                while (n != null && current >= n.val)
                {
                    n = n.next;
                }

                return n?.val ?? 0;
            }
        }
    }
}