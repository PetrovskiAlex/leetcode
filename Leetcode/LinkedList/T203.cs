using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    public class T203 : BaseLinkedListTest
    {
        [TestCase(new [] {1,2,6,3,4,5,6}, new [] {1,2,3,4,5}, 6)]
        [TestCase(new [] {6,2,6,3,4,5,6}, new [] {2,3,4,5}, 6)]
        [TestCase(new [] {6,6}, new int[0], 6)]
        [TestCase(new [] {6}, new int[0], 6)]
        public void Test(int[] input, int[] output, int target)
        {
            var head = CreateLinkedList(input);
            var empty = new ListNode(-1, head);
            var copyEmpty = empty;

            while (empty.next != null)
            {
                if (empty.next.val == target)
                {
                    empty.next = empty.next?.next;
                }
                else
                {
                    empty = empty.next;
                }
            }

            ToArray(copyEmpty.next).Should().BeEquivalentTo(output);
        }
    }
}