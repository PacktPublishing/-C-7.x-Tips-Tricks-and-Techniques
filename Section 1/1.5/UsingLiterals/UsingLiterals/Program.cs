using System;

namespace UsingLiterals
{
    static class Program
    {
        static void Main()
        {
            Separator("Decimal");
            Decimal();

            Separator("Binary");
            Binary();

            Separator("Hex");
            Hex();
        }

        private static void Decimal()
        {
            // Which looks best to you?
            const int number1 = 123;
            const int number2 = 1_2_3;
            Console.WriteLine(number1);
            Console.WriteLine(number2);

            // Which looks best to you?
            const long million1 = 1000000;
            const long million2 = 1_000_000;
            Console.WriteLine(million1);
            Console.WriteLine(million2);

            // Which looks best to you?
            const long billion1 = 1000000000;
            const long billion2 = 1_000_000_000;
            Console.WriteLine(billion1);
            Console.WriteLine(billion2);

            // Works with decicimal places too
            const decimal pi1 = 3.14159265358979323846264338m;
            const decimal pi2 = 3.141_592_653_589_793_238_462_643_38m;
            const decimal pi3 = 3.1_41_592_653589793238462_6_4338m; // Crazy, but still works
            Console.WriteLine(pi1);
            Console.WriteLine(pi2);
            Console.WriteLine(pi3);
        }

        private static void Binary()
        {
            // Which looks best to you?
            const int ten = 0b1010;
            Console.WriteLine(ten);

            const int nine = 0b10_01;
            Console.WriteLine(nine);

            const int eleven = 0b1_0_1_1;
            Console.WriteLine(eleven);

            // Which looks best now?
            const int number1 = 0b000111001000;
            const int number2 = 0b0001_1100_1000;
            Console.WriteLine(number1);
            Console.WriteLine(number2);
        }

        private static void Hex()
        {
            const long hex1 = 0xB7D96AB7;
            const long hex2 = 0xB7D9_6AB7;
            const long hex3 = 0xB7_D9_6A_B7;
            Console.WriteLine(hex1);
            Console.WriteLine(hex2);
            Console.WriteLine(hex3);
        }

        private static void Separator(string title)
        {
            var dashes = new string('-', 20);
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine(dashes);
        }
    }
}