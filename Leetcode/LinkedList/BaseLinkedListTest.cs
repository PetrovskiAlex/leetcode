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

            foreach (var number in numbers.Skip(1))
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

            while (listNode != null)
            {
                result.Add(listNode.val);

                listNode = listNode.next;
            }

            return result.ToArray();
        }
    }
}