/*
Rules: E22-3-ordinary-suffixed-candidate; E22-3-unique-attribute-candidate
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Space.Tag]
Into: [Space.Other]
*/
using System;
namespace Space { class Tag<T> { } class TagAttribute : Attribute { } class OtherAttribute : Attribute { } }
[Space.Tag] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Attribute.GetCustomAttribute(typeof(Item), typeof(Space.TagAttribute)) != null, "suffixed-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
