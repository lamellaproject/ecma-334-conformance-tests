/*
Rules: E13-6-4-unsafe-lexical-scope
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: => *pointer;
Into: => 0;
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int Read(int* pointer) => *pointer;
        int value = 6;
        Check(Read(&value) == 6, "local-function-inherits-unsafe-lexical-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
