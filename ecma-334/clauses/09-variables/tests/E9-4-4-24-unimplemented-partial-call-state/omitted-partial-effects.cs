/*
Rules: E9-4-4-24-unimplemented-partial-call-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static partial void Omit(int value);
Into: static partial void Omit(int value); static partial void Omit(int value) { }
*/
using System;
partial class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static partial void Omit(int value);
    static void Main()
    {
        int cell = 5;
        Omit(cell = 15);
        Check(cell == 5, "omitted-partial-argument-does-not-assign");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
