using System;

namespace DeconstructingTuples
{
    static class Program
    {
        static void Main()
        {
            var r = new Rectangle(55, 77);

            // Old way
            var w = r.Width;
            var h = r.Height;

            // Four ways to deconstruct a tuple:
            // ----------------------------------

            // 1: Explicitly declare the type of each field:
            (int width, int height) = r;
            (int rectWidth, int rectHeight) = r; // Not bound by names
            Console.WriteLine($"1  - {rectWidth} {rectHeight}");

            // 2: Use the var keyword so that C# infers the type of each variable
            var (width2, height2) = r; // var is placed outside the parentheses
            Console.WriteLine($"2  - {width2} {height2}");

            // 3: Use the var keyword individually with any or all of the variable declarations inside the parentheses.
            (var width3, var height3) = r;
            (int width4, var height4) = r; // Can mix var with other variable declarations (not recommended)
            Console.WriteLine($"3a - {width3} {height3}");
            Console.WriteLine($"3b - {width4} {height4}");

            // 4: Deconstruct the tuple into variables that have already been declared.
            int width5, height5;
            (width5, height5) = r;
            Console.WriteLine($"4  - {width5} {height5}");

            // Using a function
            var (sku, description, qtyInStock) = GetStock();
            (var sku2, var description2, var qtyInStock2) = GetStock();
            (string sku3, string description3, int qtyInStock3) = GetStock();
            Console.WriteLine($"Sku:{sku} Description:{description} Qty:{qtyInStock}");

            // What happends if you don't want to deconstruct all the elements in a Tuple?
            // That's where discards come into play, and the topic of our next video
        }

        private static (string sku, string description, int inStock) GetStock()
        {
            return ("HddTsh1Tb", "Toshiba 1Tb Hard drive", 5);
        }
    }

    public class Rectangle
    {
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // Must be called 'Deconstruct'
        public void Deconstruct(out int width, out int height)
        {
            width = Width;
            height = Height;
        }
    }
}
