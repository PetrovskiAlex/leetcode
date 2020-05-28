using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    /*
     * 876. Middle of the Linked List
     */
    public class T876 : BaseLinkedListTest
    {
        [TestCase(new [] {1,2,3,4,5}, 3)]
        [TestCase(new [] {1,2,3,4,5,6}, 4)]
        public void Test(int[] input, int output)
        {
            var slow = CreateLinkedList(input);
            var fast = slow.next;

            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next?.next;
            }

            slow.val.Should().Be(output);
        }
    }
}