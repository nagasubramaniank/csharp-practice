using System;

namespace DataStructures
{
    internal static class ReverseLinkedList
    {
        public static void Main(string[] args)
        {
            printReverseLinkedList(LinkedListNode<int>.Prepare());
            printReverseLinkedList(LinkedListNode<int>.Prepare(0));
            printReverseLinkedList(LinkedListNode<int>.Prepare(0, 1));
            printReverseLinkedList(LinkedListNode<int>.Prepare(0, 1, 2));
            printReverseLinkedList(LinkedListNode<int>.Prepare(0, 1, 2, 3));
        }

        private static void printReverseLinkedList<T>(LinkedListNode<T> head)
        {
            Console.WriteLine("Linked List: " + head);
            Console.WriteLine("Reverse Linked List: " + Reverse(head));
        }

        private static LinkedListNode<T> Reverse<T>(LinkedListNode<T> head)
        {
            LinkedListNode<T> forwardListHead = head, reverseListHead = null;

            while (forwardListHead != null)
            {
                LinkedListNode<T> forwardListNewHead = forwardListHead.next;
                forwardListHead.next = reverseListHead;
                reverseListHead = forwardListHead;
                forwardListHead = forwardListNewHead;
            }

            return reverseListHead;
        }
    }
}
