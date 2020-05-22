namespace LinkedList
{
    public static class ListNodeHelpers
    {
        public static ListNode Reverse(ListNode root)
        {
            ListNode prev = null;
            while (root.next != null)
            {
                var innerNext = root.next;

                root.next = prev;

                prev = root;
                root = innerNext;
            }

            root.next = prev;
 
            return root;
        }
    }
}