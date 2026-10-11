/*
Rules: E22-2-4-parameter-ulong
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(12000000000000000000UL)]
Into: [Mark(12000000000000000001UL)]
*/
using System;
class MarkAttribute : Attribute { public ulong Value; public MarkAttribute(ulong value) { Value = value; } }
[Mark(12000000000000000000UL)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ulong value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == 12000000000000000000UL, "ulong-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
