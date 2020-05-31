using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    public class T27 : BaseLinkedListTest
    {
        [TestCase(new [] {3,2,2,3}, new [] {2,2}, 3)]
        public void Test(int[] input, int[] output, int target)
        {
            var node = CreateLinkedList(input);
            var empty = new ListNode(-1, node);
            node = empty;

            var copyHead = empty;

            while (node.next != null)
            {
                if (node.next.val == target)
                {
                    node.next = node.next?.next;
                }
                else
                {
                    node = node.next;    
                }
            }

            ToArray(copyHead.next).Should().BeEquivalentTo(output);
        }
    }
}