/*
Rules: E22-3-argument-typeof-closed
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(typeof(Box<int>))]
Into: [Mark(typeof(int))]
*/
using System;
class Box<T> { }
class MarkAttribute : Attribute { public Type Value; public MarkAttribute(Type value) { Value = value; } }
[Mark(typeof(Box<int>))] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value == typeof(Box<int>), "typeof-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
