/*
Rules: E22-2-3-named-parameters; E22-2-3-field-named-parameter; E22-2-3-property-named-parameter; E22-4-3-runtime-named-value; E22-4-3-runtime-set-field; E22-4-3-runtime-set-property
Authority: ECMA-334 7th ed 22.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [Mark(Field = 41, Property = 43)]
Into: [Mark(Field = 42, Property = 43)]
*/
using System;
class MarkAttribute : Attribute { public int Field; public int Property { get; set; } }
[Mark(Field = 41, Property = 43)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        MarkAttribute a = (MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute));
        Check(a.Field == 41, "named-field");
        Check(a.Property == 43, "named-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
