using System;
using System.Linq;

namespace LinqTutorials;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Task 1");
        LinqTasks.Task1()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 2");
        LinqTasks.Task2()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 3");
        Console.WriteLine(LinqTasks.Task3());
        Console.WriteLine();
        Console.WriteLine("Task 4");
        LinqTasks.Task4()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 5");
        LinqTasks.Task5()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 6");
        LinqTasks.Task6()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 7");
        LinqTasks.Task7()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 8");
        Console.WriteLine(LinqTasks.Task8());
        Console.WriteLine();
        Console.WriteLine("Task 9");
        Console.WriteLine(LinqTasks.Task9());
        Console.WriteLine();
        Console.WriteLine("Task 10");
        LinqTasks.Task10()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 11");
        LinqTasks.Task11()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 12");
        LinqTasks.Task12()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 13");
        Console.WriteLine(LinqTasks.Task13([1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1]));
        Console.WriteLine();
        Console.WriteLine("Task 14");
        LinqTasks.Task14().ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 15");
        LinqTasks.Task15().ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Task 16");
        LinqTasks.Task16().ToList().ForEach(Console.WriteLine);
    }
}