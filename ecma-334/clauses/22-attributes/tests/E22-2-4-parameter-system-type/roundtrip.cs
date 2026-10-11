/*
Rules: E22-2-4-parameter-system-type; E22-3-argument-typeof-nongeneric
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(typeof(int))]
Into: [Mark(typeof(long))]
*/
using System;
class MarkAttribute : Attribute { public Type Value; public MarkAttribute(Type value) { Value = value; } }
[Mark(typeof(int))] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == typeof(int), "system-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
