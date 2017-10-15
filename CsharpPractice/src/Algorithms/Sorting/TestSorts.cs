using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Algorithms
{
    internal static class TestSorts
    {
        public static void Main(string[] args)
        {
            List<Type> sortGenericClasses = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.GetGenericTypeDefinition() == typeof(ISort<>))).ToList();

            foreach (Type sortGenericClass in sortGenericClasses)
            {
                Console.WriteLine(sortGenericClass.Name);

                PrintSort(sortGenericClass, new int[] { });
                PrintSort(sortGenericClass, new int[] { 0 });
                PrintSort(sortGenericClass, new int[] { 0, 0, 0, 0 });
                PrintSort(sortGenericClass, new int[] { 0, 1, 2, 3 });
                PrintSort(sortGenericClass, new int[] { 3, 2, 1, 0 });
                PrintSort(sortGenericClass, new int[] { 0, 1, 2, 3, 3, 2, 1, 0 });
                PrintSort(sortGenericClass, new int[] { 0, 4, 2, 6, 1, 5, 3, 7 });

                Console.WriteLine();
            }
        }

        private static void PrintSort<TItem>(Type sortGenericClass, TItem[] items) where TItem : IComparable<TItem>
        {
            Type sortClass = sortGenericClass.MakeGenericType(typeof(int));
            ISort<TItem> sortInstance = (ISort<TItem>) Activator.CreateInstance(sortClass, new object[0]);

            PrintItems("Before: ", items);
            TItem[] sortedItems = sortInstance.Sort(items);
            PrintItems("After: ", items);
        }

        private static void PrintItems<TItem>(string prefix, TItem[] items)
        {
            Console.Write(prefix);

            foreach (TItem item in items)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
