/*
Rules: E22-2-4-parameter-double
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(1.25)]
Into: [Mark(1.5)]
*/
using System;
class MarkAttribute : Attribute { public double Value; public MarkAttribute(double value) { Value = value; } }
[Mark(1.25)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == 1.25, "double-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
