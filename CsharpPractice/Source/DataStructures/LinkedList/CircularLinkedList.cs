using System;
using System.Text;

namespace CsharpPractice.Source.DataStructures.LinkedList
{
    internal sealed class CircularLinkedList<TValue> where TValue : IComparable<TValue>
    {
        LinkedListNode<TValue> head;

        public CircularLinkedList()
        {
            head = null;
        }

        public void Insert(TValue insertValue)
        {
            if (head == null)
            {
                this.head = new LinkedListNode<TValue> { value = insertValue };
                this.head.next = this.head;
                return;
            }

            if (insertValue.CompareTo(this.head.value) <= 0)
            {
                LinkedListNode<TValue> clonedHead = new LinkedListNode<TValue> { value = this.head.value, next = this.head.next };
                this.head.value = insertValue;
                this.head.next = clonedHead;
                return;
            }

            LinkedListNode<TValue> predecessorNode = this.head;

            for (; predecessorNode.next != this.head && predecessorNode.next.value.CompareTo(insertValue) < 0; predecessorNode = predecessorNode.next) ;

            predecessorNode.next = new LinkedListNode<TValue> { value = insertValue, next = predecessorNode.next };
        }

        public override string ToString()
        {
            if (this.head == null)
            {
                return string.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            LinkedListNode<TValue> node = this.head;

            do
            {
                stringBuilder.Append($"{node.value} ");
                node = node.next;
            }
            while (node != this.head);

            return stringBuilder.ToString();
        }
    }
}
