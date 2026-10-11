/*
Rules: E12-16-member-body; E12-16-implicit-throw-conversion
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: => throw saved
Into: => new Value()
*/
using System;
struct Value { public int N; }
class Program
{
    static Exception saved = new Exception();
    static Value Item => throw saved;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        try { Value value = Item; Check(false, "property-must-throw"); }
        catch (Exception e) { Check(object.ReferenceEquals(e, saved), "throw-expression-is-property-body"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
