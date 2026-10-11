/*
Rules: E15-7-1-property-attributes
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Stamp(26)]
Into: [Stamp(27)]
*/
using System;
class StampAttribute : Attribute { public int Code; public StampAttribute(int code) { Code = code; } }
class Box { [Stamp(26)] public int Item { get { return 4; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] attrs = typeof(Box).GetProperty("Item").GetCustomAttributes(typeof(StampAttribute), false);
        Check(attrs.Length == 1 && ((StampAttribute)attrs[0]).Code == 26, "property-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
