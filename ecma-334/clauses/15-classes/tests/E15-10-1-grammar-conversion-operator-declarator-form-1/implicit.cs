/*
Rules: E15-10-1-grammar-conversion-operator-declarator-form-1; E15-10-1-grammar-operator-declarator-form-3
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: implicit operator int(Gauge x)
Into: explicit operator int(Gauge x)
*/
using System;
class Gauge { public int Value = 17; public static implicit operator int(Gauge x) { return x.Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = new Gauge();
        Check(value == 17, "implicit-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
