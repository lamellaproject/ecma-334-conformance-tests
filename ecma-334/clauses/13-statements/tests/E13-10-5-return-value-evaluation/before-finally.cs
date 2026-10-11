/*
Rules: E13-10-5-return-value-evaluation; E13-10-5-form-return-by-value; E13-10-5-nonasync-return-to-caller
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return Read();
Into: return value;
*/
using System;
class Program
{
    static int checks, failures, trace, value = 7;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read() { trace = trace * 10 + 1; return value; }
    static int Produce()
    {
        try { return Read(); }
        finally { value = 9; trace = trace * 10 + 2; }
    }
    static void Main()
    {
        int result = Produce();
        Check(result == 7, "return-captures-before-finally-change");
        Check(value == 9, "finally-executed");
        Check(trace == 12, "return-expression-before-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
