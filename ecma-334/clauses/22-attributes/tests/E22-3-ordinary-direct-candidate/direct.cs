/*
Rules: E22-3-ordinary-direct-candidate; E22-3-unique-attribute-candidate
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Tag]
Into: [Other]
*/
using System;
class Tag : Attribute { }
class TagAttribute { }
class OtherAttribute : Attribute { }
[Tag] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Attribute.GetCustomAttribute(typeof(Item), typeof(Tag)) != null, "direct-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
