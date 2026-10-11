/*
Rules: E13-15-yield-return-expression-evaluation; E13-15-yield-return-value-conversion; E13-15-form-yield-return; E13-15-yield-movenext-true
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return Make();
Into: yield return 0L;
*/
using System;
using System.Collections.Generic;
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
    static IEnumerator<long> Items() { yield return Make(); trace = trace * 10 + 3; }
    static void Main()
    {
        IEnumerator<long> cursor = Items();
        Check(trace == 0, "iterator-expression-not-evaluated-at-call");
        bool first = cursor.MoveNext();
        Check(first && cursor.Current == 107L && trace == 12, "yield-evaluates-converts-and-sets-current");
        bool second = cursor.MoveNext();
        Check(!second && trace == 123, "yield-conversion-occurs-once-before-resumption");
        cursor.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
