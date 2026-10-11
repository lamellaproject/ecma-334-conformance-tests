/*
Rules: E22-2-2-allow-multiple-parameter; E22-2-2-multi-use
Authority: ECMA-334 7th ed 22.2.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: AllowMultiple = true
Into: AllowMultiple = false
*/
using System;
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)] class MarkAttribute : Attribute { }
[Mark, Mark] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
