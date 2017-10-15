using System;
using System.Text;

namespace DataStructures
{
    internal sealed class LinkedListNode<T>
    {
        public T value;
        public LinkedListNode<T> next;

        public static LinkedListNode<T> Prepare(params T[] sequence)
        {
            LinkedListNode<T> head = null;

            for (int index = sequence.Length - 1; index >= 0; index--)
            {
                head = new LinkedListNode<T> { value = sequence[index], next = head };
            }

            return head;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (LinkedListNode<T> node = this; node != null; node = node.next)
            {
                stringBuilder.Append(node.value + " ");
            }

            return stringBuilder.ToString();
        }
    }
}
