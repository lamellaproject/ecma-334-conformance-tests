/*
Rules: E12-8-21-item-type
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-8-21-item-type/managed-items-rejected.cs.part
Mutate: stackalloc string[1]
Into: stackalloc int[1]
*/
using System;
class Program
{
    static unsafe void Main()
    {
        void* values = stackalloc string[1];
        Console.WriteLine("OK 0");
    }
}
