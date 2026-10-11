/*
Rules: E22-3-verbatim-lookup
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [@Tag]
Into: [@TagAttribute]
*/
using System;
class Tag : Attribute { }
class TagAttribute : Attribute { }
[@Tag] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Attribute.GetCustomAttribute(typeof(Item), typeof(Tag)) != null, "verbatim-direct");
        Check(Attribute.GetCustomAttribute(typeof(Item), typeof(TagAttribute)) == null, "no-suffix-lookup");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
