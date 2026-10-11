/*
Rules: E6-2-5-is-prefer-type
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: is Needle
Into: is int
*/
using System;
class Program
{
    class Needle { }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const int Needle = 7;
        object input = new Needle();
        Check(input is Needle, "type-binding-precedes-constant-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
