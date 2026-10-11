/*
Rules: E13-10-6-throw-expression-evaluation; E13-10-1-form-throw-jump; E13-10-6-form-throw; E13-10-6-throw-expression-conversion; E13-10-6-throw-converted-exception
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/conversion-object-c58c0e7742.cs.part
Mutate: throw Make();
Into: throw replacement;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static Exception expected = new Exception(), replacement = new Exception();
    struct Source
    {
        public static implicit operator Exception(Source value) { trace = trace * 10 + 2; return expected; }
    }
    static Source Make() { trace = trace * 10 + 1; return new Source(); }
    static void Main()
    {
        Exception observed = null;
        try { throw Make(); }
        catch (Exception actual) { observed = actual; trace = trace * 10 + 3; }
        Check(observed == expected, "throw-preserves-converted-object");
        Check(trace == 123, "throw-evaluation-conversion-handler");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
