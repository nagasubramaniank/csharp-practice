// Insert values into circular linked list.

using System;

namespace CsharpPractice.Source.DataStructures.LinkedList
{
    internal static class InsertIntoCircularLinkedList
    {
        public static void Main(string[] args)
        {
            PrintInsertIntoCircularLinkedList(-4, 0, -2, 2, -3, 1, -1, 3);
        }

        private static void PrintInsertIntoCircularLinkedList<TValue>(params TValue[] values) where TValue : IComparable<TValue>
        {
            CircularLinkedList<TValue> linkedList = new CircularLinkedList<TValue>();

            Console.WriteLine($"Circular Linked List (before): {linkedList}");

            foreach (TValue value in values)
            {
                linkedList.Insert(value);
                Console.WriteLine($"Circular Linked List (after inserting {value, 2}): {linkedList}");
            }
        }
    }
}
