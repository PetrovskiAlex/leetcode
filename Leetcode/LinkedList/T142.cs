using NUnit.Framework;

namespace LinkedList
{
    public class T142 : BaseLinkedListTest
    {
        [Test]
        public void Test()
        {
            var node = CreateLinkedList(new[] {1, 2, 3, 4, 5});
            var listNode = new ListNode(7, node);

            var head = node;
            while (head.next != null)
            {
                head = head.next;
            }

            head.next = listNode;
            
            var findCycle = FindCycle(node);
        }

        private ListNode FindCycle(ListNode head)
        {
            if(head == null) return null;
        
            var slow = head;
            var fast = head;
        
            while(fast != null && fast.next != null) {           
                slow = slow.next;
                fast = fast.next.next;          
            
                if (slow == fast) {
                    break;
                }
            }

            if (slow == fast)
            {
                slow = head;
                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                } 
            }

            return slow;
        }
    }
}