/*
Rules: E22-2-4-parameter-bool
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(true)]
Into: [Mark(false)]
*/
using System;
class MarkAttribute : Attribute { public bool Value; public MarkAttribute(bool value) { Value = value; } }
[Mark(true)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == true, "bool-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
