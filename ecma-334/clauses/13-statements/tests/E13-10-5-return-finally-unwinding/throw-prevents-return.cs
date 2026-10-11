/*
Rules: E13-10-5-return-finally-unwinding
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw replacement;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static Exception replacement = new Exception();
    static int Produce()
    {
        try
        {
            try { trace = trace * 10 + 1; return 41; }
            finally { trace = trace * 10 + 2; throw replacement; }
        }
        finally { trace = trace * 10 + 3; }
    }
    static void Main()
    {
        Exception observed = null;
        bool received = false;
        try { int value = Produce(); received = true; }
        catch (Exception actual) { observed = actual; }
        Check(!received && observed == replacement, "finally-throw-cancels-return");
        Check(trace == 123, "outer-finally-still-executes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
