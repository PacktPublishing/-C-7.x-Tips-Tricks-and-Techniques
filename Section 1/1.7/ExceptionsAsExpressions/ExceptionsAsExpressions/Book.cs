using System;

namespace ExceptionsAsExpressions
{
    public class Book
    {
        private readonly IDatabase _database;

        public Book(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        /* C# 6
        public Book(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _database = database;
        }*/
    }
}