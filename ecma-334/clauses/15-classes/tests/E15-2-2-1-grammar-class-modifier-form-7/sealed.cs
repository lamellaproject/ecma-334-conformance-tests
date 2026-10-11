/*
Rules: E15-2-2-1-grammar-class-modifier-form-7
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: sealed class Gauge
Into: abstract class Gauge
*/
using System;
sealed class Gauge { public int Read() { return 101; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().Read() == 101, "sealed-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
