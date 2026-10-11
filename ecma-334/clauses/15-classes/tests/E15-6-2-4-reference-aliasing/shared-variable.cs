/*
Rules: E15-6-2-4-reference-aliasing; E15-6-2-4-reference-parameter-classification; E15-6-2-4-reference-initialization; E15-6-2-4-reference-definitely-assigned
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Edit(ref value, ref value)
Into: Edit(ref copy, ref value)
*/
using System;
class Program
{
    static int Edit(ref int first, ref int second)
    {
        int initial = first;
        second = 17;
        first += 6;
        return initial * 100 + second;
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 3;
        int copy = value;
        Check(Edit(ref value, ref value) == 323, "reference-parameters-read-and-write-shared-referent");
        Check(value == 23, "reference-assignments-change-caller-variable");
        Check(copy == 3, "unpassed-copy-retains-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
