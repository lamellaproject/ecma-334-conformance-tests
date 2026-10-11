/*
Rules: E15-12-grammar-static-constructor-declaration; E15-12-grammar-static-constructor-modifiers-form-1; E15-12-grammar-static-constructor-body-form-1; E15-12-static-constructor-attributes; E15-12-static-constructor-block-execution; E15-12-static-constructor-closed-class-initialization
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [Marker] static Gauge()
Into: [Marker] Gauge()
*/
using System;
[AttributeUsage(AttributeTargets.Constructor)] class MarkerAttribute : Attribute { }
class Gauge { public static int N; [Marker] static Gauge() { N = 13; Program.Calls++; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.N == 13, "attributed-static-constructor-value");
        Check(Calls == 1, "static-constructor-block-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
