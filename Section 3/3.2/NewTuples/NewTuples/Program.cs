using System;
using System.Collections.Generic;

namespace NewTuples
{
    // install-package System.ValueTuple
    public class Program
    {
        static void Main(string[] args)
        {
            // Unnamed tuples
            var welcome = ("Hello", "World");
            Console.WriteLine(welcome.Item1);
            Console.WriteLine(welcome.Item2);
            Console.WriteLine();

            // Named tuples
            (string hello, string world) namedWelcomeV1 = ("Hello", "World");
                                     var namedWelcomeV2 = (first: "Hello", second: "World");
            (string hello, string world) namedWelcomeV3 = (first: "Hello", second: "World");
            Console.WriteLine($"{namedWelcomeV1.hello} {namedWelcomeV1.world}");
            Console.WriteLine($"{namedWelcomeV2.first} {namedWelcomeV2.second}");
            Console.WriteLine($"{namedWelcomeV3.hello} {namedWelcomeV3.world}");
            Console.WriteLine();

            var numbers = (12, 3456, 789);
            Console.WriteLine(numbers.Item1);
            Console.WriteLine(numbers.Item2);
            Console.WriteLine(numbers.Item3);
            Console.WriteLine();

            var mixed = ("Category", 37, "Photography");
            Console.WriteLine(mixed.Item1);
            Console.WriteLine(mixed.Item2);
            Console.WriteLine(mixed.Item3);
            Console.WriteLine();

            // Tuple projection initialisers
            var count = 45;
            var name = "Simon";
            var projection = (name, count);
            var explicitName = (Forename: name, Total: count);
            Console.WriteLine($"Equality1 = {projection == explicitName}");
            var anotherCheck = ("Simon", 45);
            //var anotherCheck = ("Simon", SomeValue: 45);
            Console.WriteLine($"Equality2 = {projection == anotherCheck}");
            Console.WriteLine($"Equality3 = {explicitName == anotherCheck}");
            var cardinalityCheck = ("Simon", 45, 123);
            //Console.WriteLine($"Equality4 = {projection == cardinalityCheck}");

            // 7 elements maximum (not any more!)
            // 8 or more used to require nesting
            var seven = (1, 2, 3, 4, 5, "six", "seven");
            var eightOrMoreV1 = (seven, 8, "nine", 10, 11);
            //Console.WriteLine(eightOrMoreV1.Item1.Item1);

            var eightOrMoreV2 = (1, 2, 3, 4, 5, "six", "seven", 8, "nine", 10, 11);
            Console.WriteLine(eightOrMoreV2.Item9);
            Console.WriteLine(eightOrMoreV2.Item11);
            Console.WriteLine();

            // Functions that return tuples
            var result = Range(new[] { 45, 12, 88, 74, 86, 92, 7, 50 });
            Console.WriteLine($"Min {result.Min}");
            Console.WriteLine($"Max {result.Max}");
            Console.WriteLine();

            (int Max, int Min) Range(IEnumerable<int> nums)
            {
                int min = int.MaxValue;
                int max = int.MinValue;
                foreach (var n in nums)
                {
                    min = (n < min) ? n : min;
                    max = (n > max) ? n : max;
                }
                return (max, min);
            }
        }
    }
}
