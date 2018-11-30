using System;

namespace ReturnByReference
{
    /// <summary>
    /// Reference return values are values that a method returns by reference
    /// back to the caller. That is, the caller can modify the value returned
    /// by a method, and that change is reflected in the state of the object
    /// that contains the method.
    /// </summary>
    public static class ReferenceReturnValues
    {
        public static void Run()
        {
            var ec = new EngineerCollection();
            ec.ListEngineers();
            Console.WriteLine();

            ref var engineer = ref ec.FindBySurname("Holmes");
            if(engineer != null)
                engineer = new Engineer("Simon", "Hughes");
            ec.ListEngineers();
        }
    }
}