/*
Rules: E9-1-increment-update; E9-1-decrement-update
Authority: ECMA-334 7th ed 9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: cell++;
Into: cell--;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 24;
        cell++;
        Check(cell == 25, "increment-updates-storage");
        cell--;
        Check(cell == 24, "decrement-updates-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
