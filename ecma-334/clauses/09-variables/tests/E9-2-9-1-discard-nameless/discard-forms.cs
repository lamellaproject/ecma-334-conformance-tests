/*
Rules: E9-2-9-1-discard-nameless; E9-2-9-1-discard-declaration; E9-2-9-1-discard-implicit-type; E9-2-9-1-discard-explicit-type
Authority: ECMA-334 7th ed 9.2.9.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Write(out int _);
Into: calls++;
*/
using System;
class Program
{
    static int checks, failures, calls, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Write(out int value) { calls++; trace = trace * 10 + calls; value = calls * 9; }
    static void Main()
    {
        Write(out _);
        Check(calls == 1 && trace == 1, "implicit-discard");
        Write(out var _);
        Check(calls == 2 && trace == 12, "var-discard-reuses-no-name");
        Write(out int _);
        Check(calls == 3 && trace == 123, "explicit-discard-reuses-no-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
