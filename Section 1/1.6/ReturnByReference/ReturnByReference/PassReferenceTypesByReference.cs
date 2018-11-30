using System;

namespace ReturnByReference
{
    /// <summary>
    /// Using the ref keyword to pass reference types by reference.
    /// This enables the called method to replace the object to which
    /// the reference parameter refers in the caller.
    /// </summary>
    public static class PassReferenceTypesByReference
    {
        public static void Run()
        {
            var engineers = GetEngineers();
            Console.WriteLine("Original values");
            ListEngineers(engineers);

            Console.WriteLine();
            Console.WriteLine("Alter engineer by reference");
            ModifyEngineerNameByReference(ref engineers[1]);
            ListEngineers(engineers);

            Console.WriteLine();
            Console.WriteLine("Indirect, but uses same engineer object");
            var joe = engineers[0];
            ModifyEngineerNameByReference(ref joe);
            ListEngineers(engineers);

            Console.WriteLine();
            Console.WriteLine("Create a new engineer using the joe variable above");
            CreateNewEngineer(ref joe);
            ListEngineers(engineers);
            Console.WriteLine($"joe variable = {joe}");

            Console.WriteLine();
            Console.WriteLine("Create a new engineer using the array reference");
            CreateNewEngineer(ref engineers[2]);
            ListEngineers(engineers);
        }

        private static void ListEngineers(Engineer[] engineers)
        {
            var n = 0;
            foreach (var engineer in engineers)
            {
                Console.WriteLine($"{n++}: {engineer}");
            }
        }

        private static void ModifyEngineerNameByReference(ref Engineer engineer)
        {
            engineer.Forename = engineer.Forename.ToLowerInvariant();
            engineer.Surname = engineer.Surname.ToLowerInvariant();
        }

        private static void CreateNewEngineer(ref Engineer engineer)
        {
            engineer.Forename = "XXXXXX";
            // Think of a reference as a pointer to some memory
            // Here, we are changing the pointer to point at a new engineer
            engineer = new Engineer("Simon", "Hughes");
        }

        private static Engineer[] GetEngineers()
        {
            return new[]
            {
                new Engineer("Joe", "Bloggs"),
                new Engineer("Fred", "Ginger"),
                new Engineer("Sherlock", "Holmes")
            };
        }
    }
}