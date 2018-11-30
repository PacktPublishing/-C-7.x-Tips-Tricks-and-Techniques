namespace PatternMatching
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
        public Triangle(double baseLength, double height)
        {
            Area = height * baseLength / 2.0;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            Area = width * height;
        }
    }

    public class Unknown : Shape
    {
    }
}