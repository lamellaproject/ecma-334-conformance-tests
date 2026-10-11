/*
Rules: E9-1-storage-location; E9-1-assignment-update; E9-1-variable-type; E9-4-1-simple-assignment-not-read; E9-4-1-expression-variable-read; E9-4-4-1-expression-entry-state; E9-4-4-1-expression-end-state
Authority: ECMA-334 7th ed 9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: cell = 37;
Into: cell = 18;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 18;
        cell = 37;
        Check(cell == 37, "assigned-value-in-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
