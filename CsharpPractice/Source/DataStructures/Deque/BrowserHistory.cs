// Implement browser history that shows most recently visited sites.

using System;
using System.Collections.Generic;

namespace CsharpPractice.Source.DataStructures.Deque
{
    public static class BrowserHistory
    {
        public static void Main(string[] args)
        {
            char[] visits = new char[] { 'C', 'A', 'F', 'E', 'B', 'A', 'B', 'E' };

            Console.WriteLine("Order of Page Visits: " + string.Join(" ", visits));

            for (int historyCapacity = 1; historyCapacity <= 6; historyCapacity++)
            {
                PrintBrowserHistory(historyCapacity, visits);
            }
        }

        private static void PrintBrowserHistory<TPage>(int historyCapacity, TPage[] visits)
        {
            Browser<TPage> browser = new Browser<TPage>(historyCapacity);
            browser.VisitMultiple(visits);
            browser.PrintRecentVisits();
        }

        private class Browser<TPage>
        {
            private int historyLength;
            private readonly int historyCapacity;
            private readonly Deque<TPage> visitList;
            public readonly Dictionary<TPage, DequeNode<TPage>> visitDictionary;

            public Browser(int historyCapacity)
            {
                this.historyCapacity = historyCapacity;
                this.visitList = new Deque<TPage>();
                this.visitDictionary = new Dictionary<TPage, DequeNode<TPage>>(historyCapacity);
            }

            public void VisitMultiple(params TPage[] pages)
            {
                foreach (TPage page in pages)
                {
                    this.Visit(page);
                }
            }

            private void Visit(TPage page)
            {
                if (this.visitDictionary.ContainsKey(page))
                {
                    this.visitList.Remove(this.visitDictionary[page]);
                    this.visitList.PushFront(this.visitDictionary[page]);
                    return;
                }

                if (this.historyLength == this.historyCapacity)
                {
                    DequeNode<TPage> node = this.visitList.PopBack();
                    this.visitDictionary.Remove(node.value);
                    this.historyLength -= 1;
                }

                this.visitDictionary[page] = new DequeNode<TPage> { value = page };
                this.visitList.PushFront(this.visitDictionary[page]);
                this.historyLength += 1;
            }

            public void PrintRecentVisits()
            {
                Console.WriteLine($"Recently Visited Pages (Capacity: {this.historyCapacity}): {this.visitList}");
            }
        }
    }
}
