/*
Rules: E15-1-method-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return value + 7;
Into: return value - 7;
*/
using System;
class Meter
{
    public int Shift(int value) { return value + 7; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Meter().Shift(4) == 11, "class-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
