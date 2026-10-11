/*
Rules: E12-2-1-method-group-delegate-creation; E12-2-1-method-group-conversion
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Transform(Increment)
Into: new Transform(Decrement)
*/
using System;
class Program
{
    delegate int Transform(int value);
    static int checks, failures;
    static int Increment(int value) { return value + 7; }
    static int Decrement(int value) { return value - 7; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Transform constructed = new Transform(Increment);
        Transform converted = Increment;
        Check(constructed(8) == 15, "explicit-delegate-creation");
        Check(converted(9) == 16, "implicit-group-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
