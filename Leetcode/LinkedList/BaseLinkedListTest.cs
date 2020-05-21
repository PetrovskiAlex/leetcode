using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    public class BaseLinkedListTest
    {
        public ListNode CreateLinkedList(int[] numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                return null;
            }

            if (numbers.Length == 1)
            {
                return new ListNode(numbers.First());
            }

            var root = new ListNode(numbers.First());
            var current = root;

            foreach (var number in numbers)
            {
                var newNode = new ListNode(number);
                current.next = newNode;
                current = newNode;
            }

            return root;
        }

        public int[] ToArray(ListNode listNode)
        {
            var result = new List<int>();

            while (listNode.next != null)
            {
                result.Add(listNode.val);

                listNode = listNode.next;
            }

            return result.ToArray();
        }
    }
}