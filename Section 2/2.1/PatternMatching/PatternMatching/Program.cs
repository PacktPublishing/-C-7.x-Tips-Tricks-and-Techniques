using System;

namespace PatternMatching
{
    internal static class Program
    {
        static void Main()
        {
            TypePatterns();
            //VarPatterns();
            //ConstantPatterns();
            //IsExpressionsWithPatterns();
        }

        private static void TypePatterns()
        {
            ShowAreaUsingType(new Rectangle(3.0, 5.0));
            ShowAreaUsingType(new Triangle(2.0, 3.0));
            ShowAreaUsingType(new Triangle(30.0, 2.0));
            ShowAreaUsingType(new Triangle(10.0, 100.0));
            ShowAreaUsingType(new Unknown());
        }

        private static void ShowAreaUsingType(IShape shape)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Area of shape {shape.Area}");

            switch (shape)
            {
                case Triangle t when t.Area < 10.0:
                    Console.WriteLine($"Area of small triangle {t.Area}");
                    break;

                case Triangle t when t.Area < 50.0:
                    Console.WriteLine($"Area of medium triangle {t.Area}");
                    break;

                case Triangle t:
                    Console.WriteLine($"Area of large triangle {t.Area}");
                    break;

                case Rectangle r:
                    Console.WriteLine($"Rectangle area {r.Area}");
                    break;

                default:
                    Console.WriteLine("Unknown type");
                    break;
            }
        }

        private static void VarPatterns()
        {
            ShowAreaUsingVar(new Triangle(2.0, 3.0));
            ShowAreaUsingVar(new Triangle(10.0, 100.0));
            ShowAreaUsingVar(new Rectangle(5.0, 5.0));
            ShowAreaUsingVar(new Unknown());
        }

        private static void ShowAreaUsingVar(IShape shape)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Area of shape {shape.Area}");

            switch (shape)
            {
                case var t when t.Area < 10:
                    Console.WriteLine($"Area of smallish shape {t.Area}");
                    break;

                case var t when t.GetType().Name == "Triangle":
                    Console.WriteLine($"Area if type = 'Triangle' {t.Area}");
                    break;

                case Triangle t:
                    Console.WriteLine($"Area of triangle {t.Area}");
                    break;

                case var anything:
                    Console.WriteLine($"This could be anything. Area {anything.Area}");
                    break;

                default:
                    Console.WriteLine("Unknown type");
                    break;
            }
        }

        private static void ConstantPatterns()
        {
            ShowAreaUsingIs(null);
            ShowAreaUsingIs(new Triangle(2.0, 3.0));
            ShowAreaUsingIs(new Rectangle(5.0, 5.0));
            ShowAreaUsingIs(new Unknown());
        }

        private static void ShowAreaUsingIs(object shape)
        {
            Console.WriteLine(new string('-', 50));
            if (shape is null)
            {
                Console.WriteLine("Shape is null. Cannot continue.");
                return;
            }

            // C# 6
            if (shape is IShape)
            {
                var x = (IShape) shape;
                Console.WriteLine($"Area of shape (old) {x.Area}");
            }
            // C# 7
            if (shape is IShape s)
            {
                Console.WriteLine($"Area of shape (new) {s.Area}");
            }

            if (shape is Rectangle r)
            {
                Console.WriteLine($"Rectangle area {r.Area}");
            }
        }

        private static void IsExpressionsWithPatterns()
        {
            PrintStars1("5");
            PrintStars1(5);
            Console.WriteLine();

            PrintStars2("10");
            PrintStars2(10);
            Console.WriteLine();

            PrintStars3("15");
            PrintStars3(15);
        }

        private static void PrintStars1(object o)
        {
            if (o is null)
                return;

            if (!(o is int i))
                return; // o is not an integer

            Console.WriteLine(new string('*', i));
        }

        // Patterns and Try-methods often go well together
        private static void PrintStars2(object o)
        {
            if (o is null)
                return;

            if (o is int i || (o is string s && int.TryParse(s, out i)))
            {
                Console.WriteLine(new string('*', i));
            }
        }

        // Patterns and Try-methods often go well together
        private static void PrintStars3(object o)
        {
            switch (o)
            {
                case null:
                    return;

                case int i:
                case string s when int.TryParse(s, out i):
                    Console.WriteLine(new string('*', i));
                    break;
            }
        }
    }
}
