/*
Rules: E15-11-1-grammar-constructor-declaration; E15-11-1-grammar-constructor-modifier-form-1; E15-11-1-grammar-constructor-declarator; E15-11-1-grammar-constructor-body-form-1; E15-11-1-constructor-attributes; E15-11-1-constructor-instance-initialization; E15-11-1-constructor-block-initialization; E15-11-1-constructor-object-creation-invocation
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public Gauge(int n)
Into: private Gauge(int n)
*/
using System;
[AttributeUsage(AttributeTargets.Constructor)] class MarkerAttribute : Attribute { }
class Gauge { public int N; [Marker] public Gauge(int n) { N = n + 7; Program.Trace += "C"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(13);
        Check(item.N == 20, "constructor-initializes-instance");
        Check(Trace == "C", "constructor-block-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
