using System;

namespace OutVariables
{
    internal static class Program
    {
        public static void Main()
        {
            SingleParameter();
            MultipleParameters();
        }

        private static void SingleParameter()
        {
            // Before
            int answer1;
            int.TryParse("123", out answer1);
            Console.WriteLine(answer1);

            // After
            int.TryParse("123", out var answer2);
            Console.WriteLine(answer2);
        }

        private static void MultipleParameters()
        {
            // Before
            string forename1;
            string surname1;
            int loginCount1;
            short storyCount1;
            if(FindUser(123, out forename1, out surname1, out loginCount1, out storyCount1))
                Console.WriteLine($"{forename1} {surname1} login count: {loginCount1} stories {storyCount1}");

            // After
            if (FindUser(123, out var forename2, out var surname2, out var loginCount2, out var storyCount2))
                Console.WriteLine($"{forename2} {surname2} login count: {loginCount2} stories {storyCount2}");
        }

        /// <summary>
        /// Lookup user
        /// </summary>
        /// <returns>True if the user is found</returns>
        private static bool FindUser(int userId, out string forename, out string surname, out int loginCount, out short storyCount)
        {
            if (userId == 0)
            {
                forename = string.Empty;
                surname = string.Empty;
                loginCount = 0;
                storyCount = 0;
                return false;
            }

            forename = "Sherlock";
            surname = "Holmes";
            loginCount = 42;
            storyCount = 52;
            return true; // Found user
        }
    }
}
