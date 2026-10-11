/*
Rules: E15-2-1-declares-class
Authority: ECMA-334 7th ed 15.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Gauge { }
Into: struct Gauge { }
*/
using System;
class Gauge { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge value = null;
        Check(value == null, "class-is-reference-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
