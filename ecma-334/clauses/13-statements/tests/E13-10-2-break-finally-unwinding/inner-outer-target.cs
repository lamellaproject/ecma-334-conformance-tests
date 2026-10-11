/*
Rules: E13-10-2-break-finally-unwinding; E13-10-2-break-target-transfer; E13-10-1-jump-finally-unwinding
Authority: ECMA-334 7th ed 13.10.2
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
    static void Main()
    {
        while (true)
        {
            try { try { trace += "B"; break; } finally { trace += "I"; } }
            finally { trace += "O"; }
        }
        trace += "T";
        Check(trace == "BIOT", "break-unwinds-inner-outer-before-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
