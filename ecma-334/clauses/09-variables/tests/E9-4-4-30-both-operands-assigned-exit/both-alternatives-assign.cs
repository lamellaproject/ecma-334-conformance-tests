/*
Rules: E9-4-4-30-both-operands-assigned-exit
Authority: ECMA-334 7th ed 9.4.4.30
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (cell = 41)
Into: 41
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate) { int cell; int result = gate ? (cell = 18) : (cell = 41); return result + cell; }
    static void Main()
    {
        Check(Read(true) == 36, "true-alternative-assigned-at-exit");
        Check(Read(false) == 82, "false-alternative-assigned-at-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
