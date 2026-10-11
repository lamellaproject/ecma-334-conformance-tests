/*
Rules: E13-8-3-first-satisfied-case; E13-8-3-guard-additional-condition; E13-8-3-form-case-guard
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: case 1 when Guard(1, false):
Into: case 1 when Guard(1, true):
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Guard(int digit, bool answer) { trace = trace * 10 + digit; return answer; }
    static void Main()
    {
        int selector = 1;
        int mark = 0;
        switch (selector)
        {
            case 1 when Guard(1, false): mark = 1; break;
            case 1 when Guard(2, true): mark = 2; break;
            case 1 when Guard(3, true): mark = 3; break;
        }
        Check(trace == 12, "guards-in-lexical-order-until-match");
        Check(mark == 2, "first-satisfied-case");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
