// Reverse a linked list.

using System;

namespace DataStructures
{
    internal static class ReverseLinkedList
    {
        public static void Main(string[] args)
        {
            PrintReverseLinkedList(LinkedListNode<int>.Prepare());
            PrintReverseLinkedList(LinkedListNode<int>.Prepare(0));
            PrintReverseLinkedList(LinkedListNode<int>.Prepare(0, 1));
            PrintReverseLinkedList(LinkedListNode<int>.Prepare(0, 1, 2));
            PrintReverseLinkedList(LinkedListNode<int>.Prepare(0, 1, 2, 3));
        }

        private static void PrintReverseLinkedList<TValue>(LinkedListNode<TValue> head)
        {
            Console.WriteLine("Linked List: " + head);
            Console.WriteLine("Reverse Linked List: " + Reverse(head));
        }

        private static LinkedListNode<TValue> Reverse<TValue>(LinkedListNode<TValue> head)
        {
            LinkedListNode<TValue> forwardListHead = head, reverseListHead = null;

            while (forwardListHead != null)
            {
                LinkedListNode<TValue> forwardListNewHead = forwardListHead.next;
                forwardListHead.next = reverseListHead;
                reverseListHead = forwardListHead;
                forwardListHead = forwardListNewHead;
            }

            return reverseListHead;
        }
    }
}
