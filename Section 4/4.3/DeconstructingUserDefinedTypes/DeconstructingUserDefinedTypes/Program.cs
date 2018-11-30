using System;

namespace DeconstructingUserDefinedTypes
{
    public class Program
    {
        public static void Main()
        {
            var r = new Rectangle("a", 1, 2);
            var (name, width, height) = r;
            var (name2, _, _) = r;
            var (width2, height2) = r;

            Console.WriteLine($"{name} {width}x{height}");
            Console.WriteLine($"{name2}");
            Console.WriteLine($"{width2}x{height2}");
        }
    }

    public class Rectangle
    {
        private readonly string _name;
        private readonly int _width;
        private readonly int _height;

        public Rectangle(string name, int width, int height)
        {
            _name = name;
            _width = width;
            _height = height;
        }

        public void Deconstruct(out string name, out int width, out int height)
        {
            name = _name;
            width = _width;
            height = _height;
        }
        public void Deconstruct(out int width, out int height)
        {
            width = _width;
            height = _height;
        }
    }
}
