using System.Text;

namespace DataStructures
{
    internal sealed class LinkedListNodeWithRandomReference<T>
    {
        public T value;
        public LinkedListNodeWithRandomReference<T> next;
        public LinkedListNodeWithRandomReference<T> random;

        public LinkedListNodeWithRandomReference(T value, LinkedListNodeWithRandomReference<T> next, LinkedListNodeWithRandomReference<T> random = null)
        {
            this.value = value;
            this.next = next;
            this.random = random;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (LinkedListNodeWithRandomReference<T> node = this; node != null; node = node.next)
            {
                string randomeNodeValue = node.random == null ? "N" : node.random.value.ToString();
                stringBuilder.Append($"({ node.value }, { randomeNodeValue }) ");
            }

            return stringBuilder.ToString();
        }
    }
}
