/*
Rules: E13-10-2-break-finally-unwinding; E13-10-1-jump-finally-unwinding
Authority: ECMA-334 7th ed 13.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: finally { trace += "I"; throw marker; }
Into: finally { trace += "I"; }
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static Exception marker = new Exception();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool same = false;
        try
        {
            while (true)
            {
                try { try { trace += "B"; break; } finally { trace += "I"; throw marker; } }
                finally { trace += "O"; }
            }
            trace += "T";
        }
        catch (Exception caught) { same = object.ReferenceEquals(caught, marker); trace += "H"; }
        Check(same, "finally-exception-replaces-break");
        Check(trace == "BIOH", "outer-finally-runs-but-break-target-is-skipped");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
