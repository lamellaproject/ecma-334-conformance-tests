/*
Rules: E22-2-4-parameter-int; E22-3-argument-constant
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(37)]
Into: [Mark(38)]
*/
using System;
class MarkAttribute : Attribute { public int Value; public MarkAttribute(int value) { Value = value; } }
[Mark(37)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == 37, "int-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
