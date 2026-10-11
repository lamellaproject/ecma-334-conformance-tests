/*
Rules: E13-8-3-unmatched-switch-exit
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: case 7:
Into: case 8:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 8, trace = 1;
        switch (value) { case 7: trace = 9; break; }
        trace = trace * 10 + 2;
        Check(trace == 12, "unmatched-nonempty-switch-reaches-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
