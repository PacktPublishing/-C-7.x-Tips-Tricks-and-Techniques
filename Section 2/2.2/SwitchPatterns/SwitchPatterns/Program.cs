using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace SwitchPatterns
{
    internal static class Program
    {
        static void Main()
        {
            var shapes = new List<IShape>
            {
                new Triangle (2.0,   2.0, "Hello"), // 1
                new Triangle (10.0, 10.0, "World"), // 2
                new Triangle (2.0,   2.0, "Test"),  // 3
                new Triangle (10.0, 10.0, "Test"),  // 4
                new Rectangle(2.0,  3.0),           // 5
                new Unknown  (123.4),               // 6
                null                                // 7
            };

            SimplePatternMatchingBasedOnType(shapes);
            //SimplePatternMatchingBasedOnVar(shapes);
            //WhenClause(shapes);
            //CountItems();
            //FizzBuzz();
        }

        private static void SimplePatternMatchingBasedOnType(IEnumerable<IShape> list)
        {
            var item = 0;
            foreach (var shape in list)
            {
                Console.Write($"Item {++item}: ");
                switch (shape)
                {
                    case Triangle t:
                        Console.WriteLine($"Triangle '{t.Name}' has area {t.Area}");
                        break;

                    case Rectangle r:
                        Console.WriteLine($"Rectangle area {r.Area}");
                        break;

                    case null:
                        Console.WriteLine("is null");
                        break;

                    default:
                        Console.WriteLine($"No idea what this is, but it's area is {shape.Area}");
                        break;
                }
            }
        }

        private static void SimplePatternMatchingBasedOnVar(IEnumerable<IShape> list)
        {
            var item = 0;
            foreach (var shape in list)
            {
                Console.Write($"Item {++item}: ");
                switch (shape)
                {
                    case null: // Order of switch is important
                        Console.WriteLine("is null");
                        break;

                    case var small when small.Area < 10:
                        Console.WriteLine($"Small shape {small.Area}");
                        break;

                    case var r when r.GetType().Name == "Rectangle":
                        Console.WriteLine($"Rectangle area {r.Area}");
                        break;

                    case var matchAll:
                        Console.WriteLine($"No idea what this is, but it's area is {matchAll?.Area ?? 0.0}");
                        break;
                }
            }
        }

        private static void WhenClause(IEnumerable<IShape> list)
        {
            var item = 0;
            foreach (var shape in list)
            {
                Console.Write($"Item {++item}: ");
                switch (shape)
                {
                    case null:
                        Console.WriteLine("is null");
                        break;

                    case Triangle t when string.IsNullOrWhiteSpace(t.Name):
                        Console.WriteLine("Triangle with no name");
                        break;

                    case Triangle t when t.Name == "World":
                        Console.WriteLine($"'World' triangle has area {t.Area}");
                        break;

                    case Triangle t when t.Name == "Test" && t.Area < 20.0:
                        Console.WriteLine($"Small Test triangle with area {t.Area}");
                        break;

                    case Triangle t when t.Name == "Test":
                        Console.WriteLine($"Large Test triangle with area {t.Area}");
                        break;

                    case Triangle t: // Generic triangle catch all
                        Console.WriteLine($"'{t.Name}' generic triangle with area {t.Area}");
                        break;

                    case Rectangle r when r.IsAreaSmallerThan(10.0):
                        Console.WriteLine($"Small rectangle area {r.Area}");
                        break;

                    case Rectangle r when Math.Sqrt(r.Area) < 200:
                        Console.WriteLine($"Medium rectangle area {r.Area}");
                        break;

                    case Rectangle r: // Generic rectangle catch all
                        Console.WriteLine($"Large rectangle area {r.Area}");
                        break;

                    case var small when small.Area < 100:
                        Console.WriteLine($"Small generic shape with area of {small.Area}");
                        break;

                    case var matchAll: // Match everything else
                        Console.WriteLine($"Large generic shape with area of {matchAll.Area}");
                        break;
                }
            }
        }

        private static void CountItems()
        {
            Console.WriteLine(CountItems(new HashSet<string> { "Hello", "World" }));
            Console.WriteLine(CountItems(new List<int> { 7, 3, 8, 56, 37 }));
        }

        private static int CountItems<T>(this IEnumerable<T> list)
        {
            switch (list)
            {
                case ICollection<T> c:
                    return c.Count;

                case IReadOnlyList<T> c:
                    return c.Count;

                case IReadOnlyCollection<T> c:
                    return c.Count;

                case IProducerConsumerCollection<T> pc:
                    return pc.Count;

                // Generic catch-all if list is not null
                case IEnumerable<T> _:
                    return list.Count();

                // Default case is when list is null
                default:
                    return 0;
            }
        }

        private static void FizzBuzz()
        {
            FizzBuzz(1);
            FizzBuzz(2);
            FizzBuzz("3");
            FizzBuzz("4");
            FizzBuzz("5");

            Console.WriteLine();
            FizzBuzz(15);
            FizzBuzz("15");
            FizzBuzz("");
            FizzBuzz("## not a number ##");
            FizzBuzz(null);
        }

        private static void FizzBuzz(object o)
        {
            switch (o)
            {
                case string s when int.TryParse(s, out var n):
                    FizzBuzz(n);
                    break;
                case int n when n % 5 == 0 && n % 3 == 0:
                    Console.WriteLine("FizzBuzz");
                    break;
                case int n when n % 5 == 0:
                    Console.WriteLine("Fizz");
                    break;
                case int n when n % 3 == 0:
                    Console.WriteLine("Buzz");
                    break;
                case int n:
                    Console.WriteLine(n);
                    break;
            }
        }
    }
}
