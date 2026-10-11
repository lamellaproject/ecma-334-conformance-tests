/*
Rules: E15-10-1-grammar-conversion-operator-declarator-form-2; E15-10-1-grammar-operator-declarator-form-3
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: explicit operator int(Gauge x) { return x.Value + 3; }
Into: explicit operator int(Gauge x) { return x.Value + 4; }
*/
using System;
class Gauge { public int Value = 17; public static explicit operator int(Gauge x) { return x.Value + 3; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)new Gauge() == 20, "explicit-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
