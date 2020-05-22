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
        [TestCase(new [] {1,2,2,1}, true)]
        public void Test(int[] array, bool output)
        {
            var node = CreateLinkedList(array);
            node = ListNodeHelpers.Reverse(node);
            var init = CreateLinkedList(array);

            var result = true;
            while (node != null)
            {
                if (node.val != init.val)
                {
                    result = false;
                    break;
                }

                init = init.next;
                node = node.next;
            }

            result.Should().Be(output);
        }
    }
}