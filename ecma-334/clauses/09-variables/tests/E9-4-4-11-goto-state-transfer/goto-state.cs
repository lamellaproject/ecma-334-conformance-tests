/*
Rules: E9-4-4-11-goto-state-transfer
Authority: ECMA-334 7th ed 9.4.4.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: cell = 63;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        cell = 63;
        goto Join;
        Join: Check(cell == 63, "goto-preserves-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
