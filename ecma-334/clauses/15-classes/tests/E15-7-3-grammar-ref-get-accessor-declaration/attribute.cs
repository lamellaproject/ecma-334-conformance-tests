/*
Rules: E15-7-3-grammar-ref-get-accessor-declaration
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Tag(35)]
Into: [Tag(36)]
*/
using System;
class TagAttribute : Attribute { public int Code; public TagAttribute(int code) { Code = code; } }
class Box { int slot; public ref int Item { [Tag(35)] get { return ref slot; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] get = typeof(Box).GetProperty("Item").GetGetMethod().GetCustomAttributes(typeof(TagAttribute), false);
        Check(get.Length == 1 && ((TagAttribute)get[0]).Code == 35, "ref-get-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
