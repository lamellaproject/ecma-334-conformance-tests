/*
Rules: E15-12-grammar-static-constructor-modifiers-form-5; E15-12-grammar-static-constructor-body-form-3; E15-12-static-constructor-extern; E15-12-external-static-constructor-classification
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: extern unsafe static Gauge();
Into: extern unsafe static Gauge() { }
*/
using System;
class Gauge { extern unsafe static Gauge(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
