using System;

namespace DeconstructingTuplesWithDiscards
{
    public class Program
    {
        public static void Main()
        {
            // As a tuple
            var tuple = GetStock(1);

            // Deconstruct with discards
            var (sku, description, _, _, maxStockLevel) = GetStock(1);
            Console.WriteLine($"Sku:             {sku}");
            Console.WriteLine($"Description:     {description}");
            Console.WriteLine($"Max stock level: {maxStockLevel}");

            // Deconstruct with discards
            var (_, _, qty, _, _) = GetStock(1);
            Console.WriteLine($"Qty in stock:    {qty}");

            // Get all elements
            int minStockLevel;
            (sku, description, qty, minStockLevel, maxStockLevel) = GetStock(2);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Sku:             {sku}");
            Console.WriteLine($"Description:     {description}");
            Console.WriteLine($"Min stock level: {minStockLevel}");
            Console.WriteLine($"Max stock level: {maxStockLevel}");
            Console.WriteLine($"Qty in stock:    {qty}");

        }

        private static (string sku, string description, int qtyInStock, int minStockLevel, int maxStockLevel) GetStock(int id)
        {
            switch (id)
            {
                case 1:  return ("Veg123", "6 Green apples in a bag", 100, 40, 500);
                case 2:  return ("Car456", "Car foot pump", 6, 2, 10);
                default: return ("", "", 0, 0, 0);
            }
        }
    }
}
