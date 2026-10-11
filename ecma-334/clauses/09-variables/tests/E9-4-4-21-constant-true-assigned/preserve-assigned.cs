/*
Rules: E9-4-4-21-constant-true-assigned; E9-4-4-21-constant-false-assigned; E9-4-4-21-other-constant-state
Authority: ECMA-334 7th ed 9.4.4.21
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int cell = 81;
Into: int cell;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 81;
        if (true) Check(cell == 81, "assigned-before-constant-true");
        if (false) { } else Check(cell == 81, "assigned-before-constant-false");
        int other = 3 * 9;
        Check(other == 27 && cell == 81, "assigned-before-nonboolean-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
