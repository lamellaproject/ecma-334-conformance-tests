/*
Rules: E15-13-grammar-finalizer-declaration-form-1; E15-13-grammar-finalizer-body-form-1; E15-13-finalizer-attributes
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: [Marker] ~Gauge()
Into: [Marker] public ~Gauge()
*/
using System;
[AttributeUsage(AttributeTargets.Method)] class MarkerAttribute : Attribute { }
class Gauge { [Marker] ~Gauge() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
