using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    /*
     * 83. Remove Duplicates from Sorted List
     */
    public class T83 : BaseLinkedListTest
    {
        [TestCase(new [] {1,1,2}, new [] {1,2})]
        [TestCase(new [] {1,1,1,2}, new [] {1,2})]
        [TestCase(new [] {1,1,1,2,3,3}, new [] {1,2,3})]
        public void Test(int[] input, int[] output)
        {
            var head = CreateLinkedList(input);
            var copyHead = head;

            while (head.next != null)
            {
                if (head.val == head.next.val)
                {
                    head.next = head.next?.next;
                }
                else
                {
                    head = head.next;
                }
            }
            
            ToArray(copyHead).Should().BeEquivalentTo(output);
        }
    }
}