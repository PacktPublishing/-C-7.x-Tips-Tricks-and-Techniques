using System;

namespace ExpressionBodiedSyntax
{
    public class User
    {
        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value;
            //set => throw new NotImplementedException("Set is not allowed on Users");
        }

        public User(string email) => _email = email;
        ~User() => Console.WriteLine($"User {_email} is being destroyed");
    }
}