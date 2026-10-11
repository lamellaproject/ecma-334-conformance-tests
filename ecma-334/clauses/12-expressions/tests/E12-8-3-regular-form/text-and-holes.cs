/*
Rules: E12-8-3-regular-form; E12-8-3-regular-body; E12-8-3-regular-interpolation; E12-8-3-regular-start; E12-8-3-regular-mid; E12-8-3-regular-end; E12-8-3-regular-character-element; E12-8-3-regular-character-set; E12-8-3-regular-mid-context; E12-8-3-regular-end-context; E12-8-3-string-type; E12-8-3-string-call; E12-8-3-string-call-result; E12-8-3-default-format; E12-8-3-argument-sequence; E12-8-3-argument-order; E12-8-1-interpolated-string-form
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: $"lead:{Next(3)}mid:{Next(8)}tail"
Into: $"lead:{Next(8)}mid:{Next(3)}tail"
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next(int value) { trace = trace * 10 + value; return value; }
    static void Main()
    {
        string result = $"lead:{Next(3)}mid:{Next(8)}tail";
        Check(result == "lead:3mid:8tail", "regular-text-and-interpolations");
        Check(trace == 38, "interpolation-arguments-evaluated-left-to-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
