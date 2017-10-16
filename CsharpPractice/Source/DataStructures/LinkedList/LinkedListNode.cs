using System.Text;

namespace CsharpPractice.Source.DataStructures.LinkedList
{
    internal sealed class LinkedListNode<TValue>
    {
        public TValue value;
        public LinkedListNode<TValue> next;

        public static LinkedListNode<TValue> Prepare(params TValue[] sequence)
        {
            LinkedListNode<TValue> head = null;

            for (int index = sequence.Length - 1; index >= 0; index--)
            {
                head = new LinkedListNode<TValue> { value = sequence[index], next = head };
            }

            return head;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (LinkedListNode<TValue> node = this; node != null; node = node.next)
            {
                stringBuilder.Append(node.value + " ");
            }

            return stringBuilder.ToString();
        }
    }
}
