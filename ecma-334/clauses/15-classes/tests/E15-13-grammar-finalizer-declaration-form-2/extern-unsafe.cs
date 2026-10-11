/*
Rules: E15-13-grammar-finalizer-declaration-form-2; E15-13-grammar-finalizer-body-form-3; E15-13-external-finalizer-classification
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: extern unsafe ~Gauge();
Into: extern unsafe ~Gauge() { }
*/
using System;
class Gauge { extern unsafe ~Gauge(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
