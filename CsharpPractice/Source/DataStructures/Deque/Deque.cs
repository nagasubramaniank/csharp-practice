using System;

namespace CsharpPractice.Source.DataStructures.Deque
{
    internal sealed class Deque<TValue>
    {
        public DequeNode<TValue> front, back;

        public void PushFront(DequeNode<TValue> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (this.front == null)
            {
                node.left = node.right = null;
                this.front = this.back = node;
            }
            else
            {
                node.left = null;
                node.right = this.front;
                this.front.left = node;
                this.front = node;
            }
        }

        public DequeNode<TValue> PopBack()
        {
            DequeNode<TValue> node = this.back;

            if (this.front == this.back)
            {
                this.front = this.back = null;
            }
            else
            {
                this.back = node.left;
                this.back.right = null;
            }

            node.left = node.right = null;
            return node;
        }

        public void Remove(DequeNode<TValue> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (this.front == this.back)
            {
                this.front = this.back = null;
            }
            else if (this.front == node)
            {
                this.front = this.front.right;
                this.front.left = null;
            }
            else if (this.back == node)
            {
                this.back = this.back.left;
                this.back.right = null;
            }
            else
            {
                node.left.right = node.right;
                node.right.left = node.left;
            }

            node.left = node.right = null;
        }

        public override string ToString()
        {
            return this.front?.ToString();
        }
    }
}
