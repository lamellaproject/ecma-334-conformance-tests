/*
Rules: E22-2-4-parameter-short
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark((short)-300)]
Into: [Mark((short)-301)]
*/
using System;
class MarkAttribute : Attribute { public short Value; public MarkAttribute(short value) { Value = value; } }
[Mark((short)-300)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        short value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == (short)-300, "short-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
