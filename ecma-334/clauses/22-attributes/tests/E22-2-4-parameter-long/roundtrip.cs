/*
Rules: E22-2-4-parameter-long
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(9000000000L)]
Into: [Mark(9000000001L)]
*/
using System;
class MarkAttribute : Attribute { public long Value; public MarkAttribute(long value) { Value = value; } }
[Mark(9000000000L)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == 9000000000L, "long-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
