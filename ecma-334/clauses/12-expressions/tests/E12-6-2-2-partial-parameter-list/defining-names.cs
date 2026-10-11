/*
Rules: E12-6-2-2-partial-parameter-list
Authority: ECMA-334 7th ed 12.6.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Touch(request: 7)
Into: Touch(actual: 7)
*/
using System;
partial class Program
{
    static int checks, failures, trace;
    static partial void Touch(int request);
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Touch(request: 7);
        Check(trace == 7, "defining-partial-parameter-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
partial class Program { static partial void Touch(int actual) { trace = actual; } }
