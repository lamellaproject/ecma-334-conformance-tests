/*
Rules: E21-4-caller-search; E21-4-nearest-handler
Authority: ECMA-334 7th ed 21.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw new Exception()
Into: throw new InvalidOperationException()
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Leaf() { trace = trace * 10 + 1; throw new Exception(); }
    static void Middle()
    {
        try { Leaf(); }
        catch (InvalidOperationException) { trace = trace * 10 + 9; }
        finally { trace = trace * 10 + 2; }
    }
    static void Main()
    {
        bool caught = false;
        try { Middle(); }
        catch (Exception) { trace = trace * 10 + 3; caught = true; }
        Check(caught, "caller-enclosing-call-handles");
        Check(trace == 123, "skip-unmatched-handler-and-unwind-caller");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
