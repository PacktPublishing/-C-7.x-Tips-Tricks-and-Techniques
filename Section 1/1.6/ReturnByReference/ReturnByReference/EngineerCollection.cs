using System;

namespace ReturnByReference
{
    public class EngineerCollection
    {
        //todo: Make collection redonly
        private Engineer[] _engineers =
        {
            new Engineer("Joe", "Bloggs"),
            new Engineer("Fred", "Ginger"),
            new Engineer("Sherlock", "Holmes")
        };

        private Engineer _noEngineer;

        public ref Engineer FindBySurname(string surname)
        {
            for (var n = 0; n < _engineers.Length; ++n)
            {
                if (_engineers[n].Surname == surname)
                    return ref _engineers[n];
            }
            return ref _noEngineer;
        }

        public void ListEngineers()
        {
            var n = 0;
            foreach (var engineer in _engineers)
            {
                Console.WriteLine($"{n++}: {engineer}");
            }
        }
    }
}