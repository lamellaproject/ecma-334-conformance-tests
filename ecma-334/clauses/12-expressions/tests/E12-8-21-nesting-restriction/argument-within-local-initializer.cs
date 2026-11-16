/*
Rules: E12-8-21-nesting-restriction
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-8-21-nesting-restriction/argument-within-local-initializer.cs.part
Mutate: Echo(stackalloc int[2])
Into: Echo((int*)0)
*/
using System;
class Program
{
    static unsafe void* Echo(void* value) { return value; }
    static unsafe void Main()
    {
        void* values = Echo(stackalloc int[2]);
        Console.WriteLine("OK 0");
    }
}
