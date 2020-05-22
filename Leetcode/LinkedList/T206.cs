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

            root = ListNodeHelpers.Reverse(root);

            ToArray(root).Should().BeEquivalentTo(result);
        }
    }
}