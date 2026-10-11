/*
Rules: E9-4-4-14-try-entry; E9-4-4-14-catch-entry
Authority: ECMA-334 7th ed 9.4.4.14
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int cell = 31;
Into: int cell;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 31;
        try
        {
            Check(cell == 31, "try-entry-inherits-assignment");
            cell = 55;
            throw new Exception();
        }
        catch (Exception) { Check(cell == 55, "catch-entry-inherits-prior-assignment"); }
        Check(cell == 55, "storage-retains-try-update");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
