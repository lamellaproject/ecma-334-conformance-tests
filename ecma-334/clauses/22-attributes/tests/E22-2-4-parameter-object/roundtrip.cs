/*
Rules: E22-2-4-parameter-object
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark("box")]
Into: [Mark("crate")]
*/
using System;
class MarkAttribute : Attribute { public object Value; public MarkAttribute(object value) { Value = value; } }
[Mark("box")] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check((string)value == "box", "object-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
