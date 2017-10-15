using System;

namespace Algorithms
{
    internal sealed class ThreeWaySort<TItem> : ISort<TItem> where TItem : IComparable<TItem>
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

            // Invariance within 'while' loop:
            // All values from beginIndex .. leftIndex-1 are less than or equal to pivotValue.
            // All values from leftIndex .. currentIndex-1 are equal to pivotValue.
            // All values from rightIndex+1 .. endIndex are greater than pivotValue.

            TItem pivotValue = items[beginIndex];

            int leftIndex = beginIndex, currentIndex = beginIndex, rightIndex = endIndex;

            while (currentIndex <= rightIndex)
            {
                int comparison = items[currentIndex].CompareTo(pivotValue);

                if (comparison < 0)
                {
                    Swap(items, leftIndex++, currentIndex++);
                }
                else if (comparison > 0)
                {
                    Swap(items, currentIndex, rightIndex--);
                }
                else
                {
                    currentIndex++;
                }
            }

            Sort(items, beginIndex, leftIndex - 1);
            Sort(items, rightIndex + 1, endIndex);
        }

        private void Swap(TItem[] items, int index1, int index2)
        {
            TItem tempItem = items[index1];
            items[index1] = items[index2];
            items[index2] = tempItem;
        }
    }
}
