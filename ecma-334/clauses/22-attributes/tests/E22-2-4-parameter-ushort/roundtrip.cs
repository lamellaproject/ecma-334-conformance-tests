/*
Rules: E22-2-4-parameter-ushort
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark((ushort)60000)]
Into: [Mark((ushort)60001)]
*/
using System;
class MarkAttribute : Attribute { public ushort Value; public MarkAttribute(ushort value) { Value = value; } }
[Mark((ushort)60000)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ushort value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == (ushort)60000, "ushort-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
