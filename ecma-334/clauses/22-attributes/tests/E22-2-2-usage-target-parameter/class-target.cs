/*
Rules: E22-2-2-usage-target-parameter
Authority: ECMA-334 7th ed 22.2.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: AttributeTargets.Class
Into: AttributeTargets.Method
*/
using System;
[AttributeUsage(AttributeTargets.Class)] class MarkAttribute : Attribute { }
[Mark] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
