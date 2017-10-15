using System;

namespace DataStructures
{
    internal sealed class CloneLinkedListWithRandomReferences
    {
        public static void Main(string[] args)
        {
            // Prepare linked list.
            LinkedListNodeWithRandomReference<int> node5 = new LinkedListNodeWithRandomReference<int>(5, null);
            LinkedListNodeWithRandomReference<int> node4 = new LinkedListNodeWithRandomReference<int>(4, node5);
            LinkedListNodeWithRandomReference<int> node3 = new LinkedListNodeWithRandomReference<int>(3, node4);
            LinkedListNodeWithRandomReference<int> node2 = new LinkedListNodeWithRandomReference<int>(2, node3);
            LinkedListNodeWithRandomReference<int> node1 = new LinkedListNodeWithRandomReference<int>(1, node2);

            // Setup random references.
            node1.random = node2;
            node2.random = node4;
            node3.random = null;
            node4.random = node2;
            node5.random = node5;

            PrintCloneLinkedList(node1);
        }

        private static void PrintCloneLinkedList<TValue>(LinkedListNodeWithRandomReference<TValue> originalListHead)
        {
            Console.WriteLine("Original Linked List (Before): " + originalListHead);

            // Interleave nodes in cloned list in original list.
            for (LinkedListNodeWithRandomReference<TValue> originalListNode = originalListHead; originalListNode != null; originalListNode = originalListNode.next.next)
            {
                LinkedListNodeWithRandomReference<TValue> clonedListNode = new LinkedListNodeWithRandomReference<TValue>(originalListNode.value, originalListNode.next);
                originalListNode.next = clonedListNode; 
            }

            // Update random nodes in cloned list.
            for (LinkedListNodeWithRandomReference<TValue> originalListNode = originalListHead; originalListNode != null; originalListNode = originalListNode.next.next)
            {
                originalListNode.next.random = originalListNode.random?.next;
            }

            LinkedListNodeWithRandomReference<TValue> clonedListHead = originalListHead?.next;

            // Separate out the cloned list from original list.
            for (LinkedListNodeWithRandomReference<TValue> originalListNode = originalListHead; originalListNode != null; originalListNode = originalListNode.next)
            {
                LinkedListNodeWithRandomReference<TValue> originalListNextNode = originalListNode.next.next;
                originalListNode.next.next = originalListNextNode?.next;
                originalListNode.next = originalListNextNode;
            }

            Console.WriteLine("Original Linked List (After): " + originalListHead);
            Console.WriteLine("Cloned Linked List: " + clonedListHead);
        }
    }
}
