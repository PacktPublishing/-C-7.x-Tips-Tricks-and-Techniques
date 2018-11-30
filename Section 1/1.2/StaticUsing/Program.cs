using static System.Console;
using static System.Math;

namespace StaticUsing
{
    static class Program
    {
        static void Main()
        {
            WriteLine("Hello World");

            var a = PI * 2.0;
            var b = Pow(a, 2.0);
            WriteLine(a);
            WriteLine(b);

            const double radius = 40.0;
            var area = Floor(PI * Pow(radius, 2.0));
            WriteLine(area);
        }
    }
}
