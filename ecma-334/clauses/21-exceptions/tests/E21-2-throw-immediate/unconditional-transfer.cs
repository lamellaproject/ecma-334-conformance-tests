/*
Rules: E21-2-throw-immediate; E21-2-throw-no-fallthrough
Authority: ECMA-334 7th ed 21.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw problem;
Into: return;
*/
using System;
class Program
{
    static int checks, failures;
    static Exception problem = new Exception();
    static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Stop()
    {
        trace = 1;
        throw problem;
        trace = 8;
    }
    static void Main()
    {
        bool caught = false;
        try { Stop(); trace = 9; }
        catch (Exception error) { caught = error == problem; }
        Check(caught, "same-exception");
        Check(trace == 1, "immediate-transfer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
