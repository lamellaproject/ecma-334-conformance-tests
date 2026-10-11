/*
Rules: E13-3-2-list-next; E13-3-2-form-statement-list; E13-3-2-list-entry; E13-3-2-list-exit; E13-3-2-list-first-reachable; E13-3-2-list-successor-reachable; E13-3-2-list-end-reachable; E13-2-end-point; E13-2-reachable-definition
Authority: ECMA-334 7th ed 13.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: trace = trace * 10 + 2;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int trace = 0;
        trace = trace * 10 + 1;
        trace = trace * 10 + 2;
        trace = trace * 10 + 3;
        Check(trace == 123, "statement-sequence");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
