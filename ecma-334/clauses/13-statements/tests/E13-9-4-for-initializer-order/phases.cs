/*
Rules: E13-9-4-for-initializer-order; E13-9-4-for-iterator-order; E13-9-1-form-for-iteration; E13-9-4-form-for-expression-initializer; E13-9-4-form-for-condition; E13-9-4-form-for-iterator; E13-9-4-form-statement-expression-list; E13-9-4-for-initializer-once; E13-9-4-for-condition-evaluation; E13-9-4-for-true-body; E13-9-4-for-repeat; E13-9-4-for-false-exit
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: for (Mark("A"), Mark("B"); Gate(); Mark("I"), Step())
Into: for (Mark("B"), Mark("A"); Gate(); Mark("I"), Step())
*/
using System;
class Program
{
    static int checks, failures, iterations;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Mark(string mark) { trace = trace + mark; }
    static bool Gate() { trace = trace + "C"; return iterations < 2; }
    static void Step() { trace = trace + "J"; iterations++; }
    static void Main()
    {
        for (Mark("A"), Mark("B"); Gate(); Mark("I"), Step()) { trace = trace + "D"; }
        Check(trace == "ABCDIJCDIJC", "initializer-condition-body-iterator-order");
        Check(iterations == 2, "iterator-count");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
