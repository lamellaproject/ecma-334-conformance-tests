/*
Rules: E15-2-2-1-grammar-class-modifier-form-2; E15-2-2-1-access-modifiers
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Gauge
Into: protected class Gauge
*/
using System;
public class Gauge { public int Read() { return 73; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().Read() == 73, "public-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
