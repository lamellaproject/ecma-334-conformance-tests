/*
Rules: E13-3-1-block-in-single-position; E13-3-1-form-block; E13-3-1-empty-block-definition; E13-3-1-empty-block-control; E13-3-1-nonempty-block-entry; E13-3-1-nonempty-block-exit; E13-3-1-statement-list-reachable; E13-3-1-nonempty-block-end-reachable; E13-1-form-embedded; E13-1-embedded-block
Authority: ECMA-334 7th ed 13.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: { trace = 1; {} trace = trace * 10 + 2; }
Into: { trace = 1; {} }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int trace = 0;
        if (true) { trace = 1; {} trace = trace * 10 + 2; }
        trace = trace * 10 + 3;
        Check(trace == 123, "block-entry-empty-block-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
