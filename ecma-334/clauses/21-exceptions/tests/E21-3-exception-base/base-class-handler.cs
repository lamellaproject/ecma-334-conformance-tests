/*
Rules: E21-3-exception-base; E21-4-base-type-handler
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw original
Into: throw new Exception()
*/
using System;
class Signal : Exception { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Signal original = new Signal(); Exception root = original;
        bool matched = false;
        try { throw original; }
        catch (Exception caught) { matched = caught == root && caught is Signal; }
        Check(root == original, "implicit-conversion-to-exception-base");
        Check(matched, "base-catch-handles-derived-runtime-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
