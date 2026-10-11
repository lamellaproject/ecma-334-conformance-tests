/*
Rules: E15-10-1-grammar-operator-declaration; E15-10-1-grammar-operator-modifier-form-1; E15-10-1-grammar-operator-modifier-form-2; E15-10-1-grammar-operator-declarator-form-1; E15-10-1-grammar-unary-operator-declarator; E15-10-1-grammar-operator-body-form-1; E15-10-1-operator-member-meaning; E15-10-1-operator-block-execution
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int operator +(Gauge a)
Into: public static int operator -(Gauge a)
*/
using System;
[AttributeUsage(AttributeTargets.Method)] class MarkerAttribute : Attribute { }
class Gauge
{
    public int Value;
    public Gauge(int value) { Value = value; }
    [Marker] public static int operator +(Gauge a) { Program.Trace += "U"; return a.Value + 6; }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(13);
        Check(+item == 19, "attributed-operator-result");
        Check(Trace == "U", "operator-block-execution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
