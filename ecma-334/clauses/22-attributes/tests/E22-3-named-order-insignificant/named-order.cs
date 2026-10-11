/*
Rules: E22-3-named-order-insignificant
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [Mark(Second = 11, First = 7)]
Into: [Mark(Second = 12, First = 7)]
*/
using System;
class MarkAttribute : Attribute { public int First; public int Second { get; set; } }
[Mark(First = 7, Second = 11)] class A { }
[Mark(Second = 11, First = 7)] class B { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var a = (MarkAttribute)Attribute.GetCustomAttribute(typeof(A), typeof(MarkAttribute));
        var b = (MarkAttribute)Attribute.GetCustomAttribute(typeof(B), typeof(MarkAttribute));
        Check(a.First == 7 && a.Second == 11, "forward-named-values");
        Check(b.First == a.First && b.Second == a.Second, "reordered-named-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
