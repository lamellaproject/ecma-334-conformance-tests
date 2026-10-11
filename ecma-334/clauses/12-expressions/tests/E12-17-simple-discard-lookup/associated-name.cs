/*
Rules: E12-17-simple-discard-lookup
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Fill(out _)
Into: Fill(out var _)
*/
using System;
class Program
{
    static void Fill(out int value) { value = 41; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int _ = 3; Fill(out _); Check(_ == 41, "underscore-lookup-finds-local-instead-of-discard");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
