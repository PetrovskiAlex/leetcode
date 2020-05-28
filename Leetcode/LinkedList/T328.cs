using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    /*
     * 328. Odd Even Linked List
     */
    public class T328 : BaseLinkedListTest
    {
        [TestCase(new []{1,2,3,4,5}, new [] {1,3,5,2,4})]
        [TestCase(new []{1,2}, new [] {1,2})]
        public void Test(int[] input, int[] output)
        {
            var head = CreateLinkedList(input);
            
            ListNode odd = head;
            var copyOdd = odd;
        
            ListNode even = head.next;
            var copyEven = even;
        
            head = head.next?.next;
        
            while(head != null){
                odd.next = head;
                odd = head;
            
                even.next = head.next;
                even = head.next;
            
                head = head.next?.next;
            }

            odd.next = copyEven;

            ToArray(copyOdd).Should().BeEquivalentTo(output);
        }
    }
}