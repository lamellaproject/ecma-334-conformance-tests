/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [Mark(43)]
Into: [Mark(44)]
*/
using System;
class MarkAttribute : Attribute { public int Code; public MarkAttribute(int code) { Code = code; } }
class Grid { public int this[int index] { [Mark(43)] get { return index; } [Mark(47)] set { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool HasCode(object[] attrs, int code) { return attrs.Length == 1 && ((MarkAttribute)attrs[0]).Code == code; }
    static void Main()
    {
        System.Reflection.PropertyInfo[] properties = typeof(Grid).GetProperties();
        object[] get = properties.Length == 1 ? properties[0].GetGetMethod().GetCustomAttributes(typeof(MarkAttribute), false) : new object[0];
        object[] set = properties.Length == 1 ? properties[0].GetSetMethod().GetCustomAttributes(typeof(MarkAttribute), false) : new object[0];
        Check(HasCode(get, 43), "indexer-get-attribute");
        Check(HasCode(set, 47), "indexer-set-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
