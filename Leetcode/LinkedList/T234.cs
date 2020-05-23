using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    /*
     * Palindrome Linked List
     * Given a singly linked list, determine if it is a palindrome.
     */
    public class T234 : BaseLinkedListTest
    {
        [TestCase(new [] {1,2}, false)]
        [TestCase(new [] {1}, true)]
        [TestCase(new [] {1,2,2,1}, true)]
        [TestCase(new [] {1,2,1,2,1}, true)]
        [TestCase(new [] {1,2,1,1,2}, false)]
        [TestCase(new [] {1,1,1,1,1,1}, true)]
        [TestCase(new [] {1,1,1,1,1,2}, false)]
        public void Test(int[] array, bool output)
        {
            var node = CreateLinkedList(array);
            var copyNode = node;
            var length = 0;

            while (copyNode != null)
            {
                copyNode = copyNode.next;
                length++;
            }

            copyNode = node;
            var middle = length % 2 == 0 ? length / 2 : length / 2 + 1;
            var count = length % 2 == 0 ? 0 : 1;
            while (count < middle)
            {
                copyNode = copyNode.next;
                count++;
            }

            var result = true;
            var listNode = ListNodeHelpers.Reverse(copyNode);
            count = 0;
            while (count < middle)
            {
                if (listNode.val != node.val)
                {
                    result = false;
                    break;
                }

                listNode = listNode.next;
                node = node.next;
                count++;
            }

            result.Should().Be(output);
        }
    }
}