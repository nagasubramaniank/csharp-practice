using System.Collections.Generic;

namespace CsharpPractice.Source.DataStructures.Trie
{
    interface ITrieItem
    {
        IEnumerable<string> GetKeywords();
    }
}
