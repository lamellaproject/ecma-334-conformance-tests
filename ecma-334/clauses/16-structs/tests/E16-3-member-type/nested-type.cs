/*
Rules: E16-3-member-type
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public struct Child
Into: private struct Child
*/
using System;
struct Parent { public struct Child { public int Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent.Child item = new Parent.Child(); item.Value = 109;
        Check(item.Value == 109, "nested-type-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
