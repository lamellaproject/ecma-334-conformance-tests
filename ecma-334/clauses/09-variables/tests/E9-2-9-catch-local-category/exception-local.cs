/*
Rules: E9-2-9-catch-local-category; E9-2-9-catch-local-initially-assigned; E9-4-2-catch-variable-assigned
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw marker;
Into: throw new Exception();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception marker = new Exception();
        try { throw marker; }
        catch (Exception cell) { Check(cell == marker, "catch-local-holds-caught-instance"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
