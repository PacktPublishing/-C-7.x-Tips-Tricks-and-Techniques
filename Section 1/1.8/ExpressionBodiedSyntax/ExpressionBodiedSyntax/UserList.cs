namespace ExpressionBodiedSyntax
{
    public class UserList
    {
        private readonly User[] _users =
        {
            new User("fred.bloggs@hotmail.com"),
            new User("Joe.Smith@gmail.com")
        };

        /// Indexer with expression body syntax.
        public User this[int index]
        {
            get => _users[index];
            set => _users[index] = value;
        }
    }
}