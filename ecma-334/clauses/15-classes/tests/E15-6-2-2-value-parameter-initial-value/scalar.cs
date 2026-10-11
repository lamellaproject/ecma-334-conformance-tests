/*
Rules: E15-6-2-2-value-parameter-initial-value; E15-6-2-2-value-parameter-classification; E15-6-2-2-value-parameter-assignment; E15-6-2-2-value-parameter-assignment-is-local
Authority: ECMA-334 7th ed 15.6.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: value = 17;
Into: value = 19;
*/
using System;
class Program
{
    static int Edit(int value) { int prior = value; value = 17; return prior * 100 + value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int original = 11;
        Check(Edit(original) == 1117, "value-parameter-has-argument-value-and-can-be-assigned");
        Check(original == 11, "value-parameter-assignment-preserves-caller-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
