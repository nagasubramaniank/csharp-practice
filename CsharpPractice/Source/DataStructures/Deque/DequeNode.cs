using System.Text;

namespace CsharpPractice.Source.DataStructures.Deque
{
    internal sealed class DequeNode<TValue>
    {
        public TValue value;
        public DequeNode<TValue> left, right;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (DequeNode<TValue> node = this; node != null; node = node.right)
            {
                stringBuilder.Append(node.value + " ");
            }

            return stringBuilder.ToString();
        }
    }
}
