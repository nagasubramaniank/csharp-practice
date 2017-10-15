// Quick sort algorithm.

using System;

namespace Algorithms
{
    internal sealed class QuickSort<TItem> : ISort<TItem> where TItem : IComparable<TItem>
    {
        public TItem[] Sort(TItem[] items)
        {
            Sort(items, 0, items.Length - 1);
            return items;
        }

        private void Sort(TItem[] items, int beginIndex, int endIndex)
        {
            if (beginIndex >= endIndex)
            {
                return;
            }

            int pivotIndex = Partition(items, beginIndex, endIndex);
            Sort(items, beginIndex, pivotIndex - 1);
            Sort(items, pivotIndex + 1, endIndex);
        }

        private int Partition(TItem[] items, int beginIndex, int endIndex)
        {
            TItem pivotValue = items[beginIndex];
            int leftIndex = beginIndex + 1, rightIndex = endIndex;

            // Invariance within 'while' loop:
            // All values from beginIndex .. leftIndex-1 are less than or equal to pivotValue.
            // All values from rightIndex+1 .. endIndex are greater than pivotValue.

            while (true)
            {
                while (leftIndex <= rightIndex && items[leftIndex].CompareTo(pivotValue) <= 0)
                {
                    leftIndex++;
                }

                while (items[rightIndex].CompareTo(pivotValue) > 0)
                {
                    rightIndex--;
                }

                if (leftIndex > rightIndex)
                {
                    break;
                }

                Swap(items, leftIndex, rightIndex);
            }

            Swap(items, beginIndex, leftIndex - 1);
            return leftIndex - 1;
        }

        private void Swap(TItem[] items, int index1, int index2)
        {
            TItem tempItem = items[index1];
            items[index1] = items[index2];
            items[index2] = tempItem;
        }
    }
}
