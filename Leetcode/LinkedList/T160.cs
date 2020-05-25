using FluentAssertions.Common;
using NUnit.Framework;

namespace LinkedList
{
    /*
     * 160. Intersection of Two Linked Lists
     *
     * Write a program to find the node at which the intersection of two singly linked lists begins.
     */
    public class T160 : BaseLinkedListTest
    {
        [TestCase(new [] {4,1,8,4,5}, new [] {5,0,1,8,4,5}, new [] {8,4,5})]
        public void Test(int[] first, int[] second, int[] intersection)
        {
            var headA = CreateLinkedList(first);
            var headB = CreateLinkedList(second);
            var intersectionHead = CreateLinkedList(intersection);

            while (headA.val != intersectionHead.val)
            {
                headA = headA.next;
            }
            headA.next = intersectionHead;

            while (headB.val != intersectionHead.val)
            {
                headB = headB.next;
            }
            headB.next = intersectionHead;

            var copyHeadA = headA;
            var copyHeadB = headB;
        
            var flagA = 0;
            var flagB = 0;
        
            while(flagA != 2 || flagB != 2){
                if (headA == headB) break; 
            
                if(headA == null){
                    flagA++;
                    headA = copyHeadB;
                }
                else{
                    headA = headA.next;
                }
            
            
                if(headB == null){
                    flagB++;
                    headB = copyHeadA;
                }
                else{
                    headB = headB.next;
                }
            }

            headA.IsSameOrEqualTo(intersectionHead);
        }
    }
}