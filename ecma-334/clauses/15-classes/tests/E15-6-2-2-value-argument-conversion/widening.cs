/*
Rules: E15-6-2-2-value-argument-conversion
Authority: ECMA-334 7th ed 15.6.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static long Read(long value)
Into: static long Read(char value)
*/
using System;
class Program
{
    static long Read(long value) { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte original = 31;
        Check(Read(original) == 31L, "implicit-widening-conversion-initializes-value-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
