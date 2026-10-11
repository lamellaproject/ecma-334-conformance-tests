/*
Rules: E22-2-4-parameter-enum
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(Mode.Second)]
Into: [Mark(Mode.First)]
*/
using System;
enum Mode { First, Second }
class MarkAttribute : Attribute { public Mode Value; public MarkAttribute(Mode value) { Value = value; } }
[Mark(Mode.Second)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Mode value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == Mode.Second, "enum-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
