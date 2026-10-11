/*
Rules: E9-4-4-7-guard-pattern-variable-assigned; E9-4-4-7-guarded-label-transfer
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (cell = pattern + 3) > 0
Into: pattern + 3 > 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(object source)
    {
        int cell;
        switch (source)
        {
            case int pattern when (cell = pattern + 3) > 0: return cell;
            default: return -1;
        }
    }
    static void Main()
    {
        Check(Read(16) == 19, "pattern-readable-and-guard-assigns-body");
        Check(Read(-10) == -1, "failed-guard-does-not-read-body-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
