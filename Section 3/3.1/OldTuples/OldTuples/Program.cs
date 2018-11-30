using System;

namespace OldTuples
{
    public class Program
    {
        static void Main(string[] args)
        {
            var welcome = Tuple.Create("Hello", "World");
            Console.WriteLine(welcome.Item1);
            Console.WriteLine(welcome.Item2);
            Console.WriteLine();

            var numbers = Tuple.Create(12, 3456, 789);
            Console.WriteLine(numbers.Item1);
            Console.WriteLine(numbers.Item2);
            Console.WriteLine(numbers.Item3);
            Console.WriteLine();

            var mixed = Tuple.Create("Category", 37, "Photography");
            Console.WriteLine(mixed.Item1);
            Console.WriteLine(mixed.Item2);
            Console.WriteLine(mixed.Item3);
            Console.WriteLine();

            // 7 elements maximum
            var seven = Tuple.Create(1, 2, 3, 4, 5, "six", "seven");

            // 8 or more require nesting
            var eightOrMore = Tuple.Create(seven, 8, "nine", 10, 11);
        }
    }
}
