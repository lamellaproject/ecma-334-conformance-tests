/*
Rules: E22-2-4-parameter-uint
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(3000000000U)]
Into: [Mark(3000000001U)]
*/
using System;
class MarkAttribute : Attribute { public uint Value; public MarkAttribute(uint value) { Value = value; } }
[Mark(3000000000U)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        uint value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == 3000000000U, "uint-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
