/*
Rules: E22-2-4-parameter-sbyte
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark((sbyte)-7)]
Into: [Mark((sbyte)-6)]
*/
using System;
class MarkAttribute : Attribute { public sbyte Value; public MarkAttribute(sbyte value) { Value = value; } }
[Mark((sbyte)-7)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == (sbyte)-7, "sbyte-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
