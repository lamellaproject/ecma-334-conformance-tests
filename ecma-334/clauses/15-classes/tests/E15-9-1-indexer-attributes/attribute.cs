/*
Rules: E15-9-1-indexer-attributes
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(41)]
Into: [Mark(42)]
*/
using System;
class MarkAttribute : Attribute { public int Code; public MarkAttribute(int code) { Code = code; } }
class Grid { [Mark(41)] public int this[int index] => index; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        System.Reflection.PropertyInfo[] properties = typeof(Grid).GetProperties();
        object[] attrs = properties.Length == 1 ? properties[0].GetCustomAttributes(typeof(MarkAttribute), false) : new object[0];
        Check(attrs.Length == 1 && ((MarkAttribute)attrs[0]).Code == 41, "indexer-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
