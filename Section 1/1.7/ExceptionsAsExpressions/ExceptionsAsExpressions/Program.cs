using System;

namespace ExceptionsAsExpressions
{
    static class Program
    {
        static void Main()
        {
            // C# 6
            var book = FindBook("Dianiel Suarez");
            if(book == null)
                throw new InvalidOperationException("Could not find book");

            // C# 7
            book = FindBook("Dianiel Suarez") ??
                throw new InvalidOperationException("Could not find book");
        }

        static Book FindBook(string author)
        {
            return new Book(null);
        }
    }
}
