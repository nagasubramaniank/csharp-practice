using System;
using System.Collections.Generic;

namespace CsharpPractice.Source.DataStructures.Trie
{
    internal class TrieNode<TItem>
    {
        private readonly TrieNode<TItem>[] children = new TrieNode<TItem>[26];
        private readonly List<TItem> items = new List<TItem>();

        public void Insert(string remainingString, TItem item)
        {
            if (string.IsNullOrEmpty(remainingString))
            {
                this.items.Add(item);
                return;
            }

            int index = char.ToLower(remainingString[0]) - 'a';

            if (index < 0 || index >= 26)
            {
                throw new ArgumentException($"Encountered invalid character: [{remainingString[0]}].");
            }

            if (this.children[index] == null)
            {
                this.children[index] = new TrieNode<TItem>();
            }

            this.children[index].Insert(remainingString.Substring(1), item);
        }

        public IEnumerable<TItem> Search(string remainingPattern)
        {
            if (string.IsNullOrEmpty(remainingPattern))
            {
                return this.Gather();
            }

            int index = char.ToLower(remainingPattern[0]) - 'a';

            if (index < 0 || index >= 26)
            {
                throw new ArgumentException($"Encountered invalid character: [{remainingPattern[0]}].");
            }

            if (this.children[index] == null)
            {
                return new List<TItem>();
            }

            return this.children[index].Search(remainingPattern.Substring(1));
        }

        private List<TItem> Gather()
        {
            List<TItem> gatherItems = new List<TItem>();
            this.Gather(gatherItems);
            return gatherItems;
        }

        private void Gather(List<TItem> gatherItems)
        {
            gatherItems.AddRange(this.items);

            foreach (TrieNode<TItem> child in this.children)
            {
                if (child != null)
                {
                    child.Gather(gatherItems);
                }
            }
        }
    }
}
