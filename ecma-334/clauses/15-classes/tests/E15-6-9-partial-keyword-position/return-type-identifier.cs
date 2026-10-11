/*
Rules: E15-6-9-partial-keyword-position
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static partial Produce()
Into: static object Produce()
*/
using System;
class partial { public int Value = 59; }
class Program
{
    static partial Produce() { return new partial(); }
    static int partial() { return 97; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Produce().Value == 59, "partial-before-method-name-is-a-return-type-identifier");
        Check(partial() == 97, "partial-can-be-an-ordinary-method-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
