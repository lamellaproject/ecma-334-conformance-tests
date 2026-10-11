/*
Rules: E13-10-3-continue-finally-unwinding; E13-10-3-continue-target-transfer
Authority: ECMA-334 7th ed 13.10.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: finally { trace += "I"; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next(int value) { trace += "N"; return value + 1; }
    static void Main()
    {
        for (int step = 0; step < 2; step = Next(step))
        {
            try { try { trace += "B"; continue; } finally { trace += "I"; } }
            finally { trace += "O"; }
        }
        Check(trace == "BIONBION", "continue-unwinds-inner-outer-before-iterator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
