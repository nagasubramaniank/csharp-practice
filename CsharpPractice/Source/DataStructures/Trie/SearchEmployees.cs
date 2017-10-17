using System;
using System.Collections.Generic;

namespace CsharpPractice.Source.DataStructures.Trie
{
    internal static class SearchEmployees
    {
        public static void Main(string[] args)
        {
            Trie<Employee> trie = new Trie<Employee>();

            Employee[] employees = new Employee[]
            {
                new Employee("Sourabh", "Sharma"),
                new Employee("Abhishek", "Agarwal"),
                new Employee("Abhishek", "Kumar"),
                new Employee("Anup", "Agarwal"),
                new Employee("Anupam", "Sharma"),
                new Employee("Sourabh", "Agarwal"),
            };

            foreach (Employee employee in employees)
            {
                trie.Insert(employee);
            }

            string[] patterns = new string[] { "", "A", "Aa", "Abhi", "Sharma", "anup", "anupam", "anupama" };

            foreach (string pattern in patterns)
            {
                Console.WriteLine($"Pattern: [{pattern}]:");

                foreach (Employee selectedEmployee in trie.Search(pattern))
                {
                    Console.WriteLine($"\tSelected Employee: [{selectedEmployee}]");
                }

                Console.WriteLine();
            }
        }

        private class Employee : ITrieItem
        {
            public readonly string firstName;
            public readonly string lastName;

            public Employee(string firstName, string lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }

            public IEnumerable<string> GetKeywords()
            {
                yield return firstName;
                yield return lastName;
            }

            public override string ToString()
            {
                return firstName + " " + lastName;
            }
        }
    }
}
