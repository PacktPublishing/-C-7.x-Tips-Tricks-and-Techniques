using System.Collections.Specialized;

namespace SwitchPatterns
{
    public interface IShape
    {
        double Area { get; set; }
    }

    public abstract class Shape : IShape
    {
        public double Area { get; set; }
    }

    public class Triangle : Shape
    {
        public string Name { get; set; }

        public Triangle(double baseLength, double height, string name)
        {
            Area = height * baseLength / 2.0;
            Name = name;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            Area = width * height;
        }

        public bool IsAreaSmallerThan(double area)
        {
            return Area < area;
        }
    }

    public class Unknown : Shape
    {
        public Unknown(double area)
        {
            Area = area;
        }
    }
}