/*
Rules: E22-2-4-parameter-byte
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark((byte)13)]
Into: [Mark((byte)14)]
*/
using System;
class MarkAttribute : Attribute { public byte Value; public MarkAttribute(byte value) { Value = value; } }
[Mark((byte)13)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == (byte)13, "byte-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
