/*
Rules: E15-11-1-grammar-constructor-modifier-form-5; E15-11-1-grammar-constructor-body-form-3; E15-11-1-constructor-extern; E15-11-1-external-constructor-classification
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public extern Gauge();
Into: public extern Gauge() { }
*/
using System;
class Gauge { public extern Gauge(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
