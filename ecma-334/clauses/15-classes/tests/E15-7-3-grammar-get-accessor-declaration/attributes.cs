/*
Rules: E15-7-3-grammar-get-accessor-declaration; E15-7-3-grammar-set-accessor-declaration
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [Tag(14)]
Into: [Tag(15)]
*/
using System;
class TagAttribute : Attribute { public int Code; public TagAttribute(int code) { Code = code; } }
class Box { int slot; public int Item { [Tag(14)] get { return slot; } [Tag(27)] set { slot = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] get = typeof(Box).GetProperty("Item").GetGetMethod().GetCustomAttributes(typeof(TagAttribute), false);
        object[] set = typeof(Box).GetProperty("Item").GetSetMethod().GetCustomAttributes(typeof(TagAttribute), false);
        Check(get.Length == 1 && ((TagAttribute)get[0]).Code == 14, "get-attribute");
        Check(set.Length == 1 && ((TagAttribute)set[0]).Code == 27, "set-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
