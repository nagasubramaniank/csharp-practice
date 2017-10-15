using System;

namespace Algorithms
{
    internal interface ISort<TItem> where TItem : IComparable<TItem>
    {
        TItem[] Sort(TItem[] items);
    }
}
