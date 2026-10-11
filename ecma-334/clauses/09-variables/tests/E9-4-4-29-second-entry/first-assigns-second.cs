/*
Rules: E9-4-4-29-second-entry; E9-4-4-29-other-coalescing-exit
Authority: ECMA-334 7th ed 9.4.4.29
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Left(out cell)
Into: Left(out _)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static string Left(out int value) { value = 17; return null; }
    static void Main()
    {
        int cell;
        string result = Left(out cell) ?? (cell == 17 ? "right" : "bad");
        Check(result == "right", "first-operand-assignment-at-second-entry");
        Check(cell == 17, "first-operand-state-at-coalescing-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
