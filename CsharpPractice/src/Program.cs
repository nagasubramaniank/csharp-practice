using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class Program
{
    public static void Main(string[] args)
    {
        List<Type> allClasses =
            Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.GetMethod("Main") != null).ToList();

        List<string> namespaces =
            allClasses.Select(c => c.Namespace).Where(n => !string.IsNullOrEmpty(n)).Distinct().OrderBy(n => n).ToList();

        Console.WriteLine("List of namespaces:");

        for (int i = 0; i < namespaces.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {namespaces[i]}");
        }

        Console.Write("\nEnter namespace ID (0 to quit): ");

        int namespaceId;
        if (!int.TryParse(Console.ReadLine(), out namespaceId) || namespaceId <= 0 || namespaceId > namespaces.Count)
        {
            return;
        }

        Console.WriteLine();

        List<string> classes = allClasses.Where(c => c.Namespace == namespaces[namespaceId - 1] && !c.Name.Contains('_'))
            .Select(c => c.Name).OrderBy(n => n).ToList();

        Console.WriteLine("List of classes:");

        for (int i = 0; i < classes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {classes[i]}");
        }

        Console.Write("\nEnter class ID (0 to quit): ");

        int classId;
        if (!int.TryParse(Console.ReadLine(), out classId) || classId <= 0 || classId > classes.Count)
        {
            return;
        }

        Console.WriteLine();

        Type.GetType(namespaces[namespaceId - 1] + '.' + classes[classId - 1]).GetMethod("Main")
            .Invoke(null, new object[] { new string[0] });

        Console.ReadKey();
    }
}
