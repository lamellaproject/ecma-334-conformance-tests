/*
Rules: E23-7-string-initializer
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: fixed (void* pointer = text)
Into: fixed (void* pointer = other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        string text = "reed", other = "seed";
        fixed (void* pointer = text) Check(*(char*)pointer == 'r', "string-initializer-void-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
