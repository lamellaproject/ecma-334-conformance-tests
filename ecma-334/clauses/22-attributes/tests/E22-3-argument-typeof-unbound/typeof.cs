/*
Rules: E22-3-argument-typeof-unbound
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark(typeof(Box<>))]
Into: [Mark(typeof(int))]
*/
using System;
class Box<T> { }
class MarkAttribute : Attribute { public Type Value; public MarkAttribute(Type value) { Value = value; } }
[Mark(typeof(Box<>))] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value == typeof(Box<>), "typeof-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
