using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    public class T206 : BaseLinkedListTest
    {
        /*
         * Reverse ListNode
         */
        
        [TestCase(new []{1,2,3,4,5}, new []{5,4,3,2,1})]
        public void Test(int[] source, int[] result)
        {
            var root = CreateLinkedList(source);

            ListNode prev = null;
            while (root.next != null)
            {
                var next = root.next;

                root.next = prev;

                prev = root;
                root = next;
            }

            root.next = prev;

            ToArray(root).Should().BeEquivalentTo(result);
        }
    }
}