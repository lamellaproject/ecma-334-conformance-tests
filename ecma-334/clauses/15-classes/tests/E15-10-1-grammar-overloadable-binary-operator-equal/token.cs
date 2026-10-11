/*
Rules: E15-10-1-grammar-overloadable-binary-operator-equal; E15-10-1-grammar-operator-declarator-form-2; E15-10-1-grammar-binary-operator-declarator
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: bool operator ==(Gauge a, Gauge b) { return a.Value == b.Value; }
Into: bool operator ==(Gauge a, Gauge b) { return !(a.Value == b.Value); }
*/
using System;
class Gauge
{
    public int Value;
    public Gauge(int n) { Value = n; }
    public static bool operator ==(Gauge a, Gauge b) { return a.Value == b.Value; }
    public static bool operator !=(Gauge a, Gauge b) { return a.Value != b.Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((new Gauge(13) == new Gauge(5)) == false, "binary-equal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
