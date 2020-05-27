using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LinkedList
{
    public class T19 : BaseLinkedListTest
    {
        [TestCase(new[] {1, 2, 3, 4, 5}, new[] {1, 2, 3, 5}, 2)]
        [TestCase(new[] {1, 2, 3, 4, 5}, new[] {1, 2, 3, 4}, 1)]
        [TestCase(new[] {1, 2, 3, 4, 5}, new[] {2, 3, 4, 5}, 5)]
        public void Test(int[] input, int[] output, int n)
        {
            var node = CreateLinkedList(new [] {-1}.Concat(input).ToArray());
            var result = node;
            var copyNode = node;

            for (int i = 0; i < n; i++)
            {
                node = node.next;
            }

            while (node.next != null)
            {
                copyNode = copyNode.next;
                node = node.next;
            }

            copyNode.next = copyNode.next?.next;

            ToArray(result.next).Should().BeEquivalentTo(output);
        }
    }
}