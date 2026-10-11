/*
Rules: E13-10-5-return-value-conversion; E13-10-5-return-converted-result
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return Make();
Into: return 0L;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    struct Number
    {
        public int Value;
        public static implicit operator long(Number value) { trace = trace * 10 + 2; return value.Value + 100; }
    }
    static Number Make() { trace = trace * 10 + 1; return new Number { Value = 7 }; }
    static long Produce()
    {
        try { return Make(); }
        finally { trace = trace * 10 + 3; }
    }
    static void Main()
    {
        long actual = Produce();
        Check(actual == 107L, "return-conversion-result");
        Check(trace == 123, "evaluation-conversion-before-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
