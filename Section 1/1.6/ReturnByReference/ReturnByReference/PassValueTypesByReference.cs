using System;

namespace ReturnByReference
{
    /// <summary>
    /// Using the ref keyword to pass value types by reference, not by value.
    /// This enables the called method to replace the value to which
    /// the reference parameter refers in the caller.
    /// </summary>
    public static class PassValueTypesByReference
    {
        public static void Run()
        {
            var number = 0;

            Calculate(ref number);
            Console.WriteLine(number);

            Calculate(ref number);
            Console.WriteLine(number);

            number = 100;
            Calculate(ref number);
            Console.WriteLine(number);
        }

        // An argument that is passed as a ref or in parameter must be initialized
        // before it is passed.
        // Out parameters however do not have to be initialized before they are passed.
        private static void Calculate(ref int number)
        {
            number += 11;
        }
    }
}