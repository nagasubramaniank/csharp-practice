using System.Collections.Generic;
using System.Linq;

namespace CsharpPractice.Source.DataStructures.Trie
{
    internal class Trie<TItem> where TItem : ITrieItem
    {
        private readonly TrieNode<TItem> rootNode = new TrieNode<TItem>();

        public void Insert(TItem item)
        {
            foreach (string keyword in item.GetKeywords())
            {
                rootNode.Insert(keyword, item);
            }
        }

        public IEnumerable<TItem> Search(string pattern)
        {
            return rootNode.Search(pattern).Distinct();
        }
    }
}
