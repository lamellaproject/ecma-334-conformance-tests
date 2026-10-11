/*
Rules: E9-2-9-pattern-local-category
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object source = 57;
Into: object source = "57";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = 57;
        bool matched = false;
        if (source is int cell) { matched = true; Check(cell == 57, "pattern-introduces-value-local"); }
        Check(matched, "pattern-branch-executed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
