using System;

namespace CsharpPractice.Source.Algorithms.Sorting
{
    internal interface ISort<TItem> where TItem : IComparable<TItem>
    {
        TItem[] Sort(TItem[] items);
    }
}
