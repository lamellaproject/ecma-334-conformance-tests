/*
Rules: E15-12-grammar-static-constructor-modifiers-form-2; E15-12-grammar-static-constructor-body-form-3; E15-12-static-constructor-extern; E15-12-external-static-constructor-classification
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: static extern unsafe Gauge();
Into: static extern unsafe Gauge() { }
*/
using System;
class Gauge { static extern unsafe Gauge(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
