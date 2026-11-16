/*
Rules: E12-8-21-negative-constant-length
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-8-21-negative-constant-length/negative-count-rejected.cs.part
Mutate: stackalloc int[-2]
Into: stackalloc int[2]
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int* values = stackalloc int[-2];
        Console.WriteLine("OK 0");
    }
}
