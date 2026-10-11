/*
Rules: E15-1-static-constructor-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static Meter() { Reading = 41; }
Into: static Meter() { Reading = 0; }
*/
using System;
class Meter
{
    public static int Reading;
    static Meter() { Reading = 41; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Meter.Reading == 41, "class-static-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
