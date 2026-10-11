/*
Rules: E12-6-6-1-static-arguments; E12-6-6-1-static-invoke; E12-6-6-1-static-category; E12-6-6-1-member-result
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick(Argument(1), Argument(2))
Into: Pick(Argument(2), Argument(1))
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Argument(int id) { trace = trace * 10 + id; return id; }
    static int Pick(int first, int second) { trace = trace * 10 + 3; return first * 10 + second; }
    static void Main()
    {
        int result = Pick(Argument(1), Argument(2));
        Check(trace == 123, "arguments-evaluated-left-to-right-before-static-body");
        Check(result == 12, "static-invocation-returns-body-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
