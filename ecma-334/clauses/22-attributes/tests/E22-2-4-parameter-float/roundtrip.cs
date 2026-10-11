/*
Rules: E22-2-4-parameter-float
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(1.25f)]
Into: [Mark(1.5f)]
*/
using System;
class MarkAttribute : Attribute { public float Value; public MarkAttribute(float value) { Value = value; } }
[Mark(1.25f)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == 1.25f, "float-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
