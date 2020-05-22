using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    /*
     * Delete Node in a Linked List
     * Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
     */
    public class T237 : BaseLinkedListTest
    {
        [TestCase(2, new [] {1,3,4,5})]
        [TestCase(1, new [] {2,3,4,5})]
        [TestCase(3, new [] {1,2,4,5})]
        public void Test(int element, int[] output)
        {
            var node = CreateLinkedList(new []{1,2,3,4,5});

            var root = node;
            while (root.val != element)
            {
                root = root.next;
            }

            root.val = root.next.val;
            root.next = root.next.next;

            ToArray(node).Should().BeEquivalentTo(output);
        }
    }
}