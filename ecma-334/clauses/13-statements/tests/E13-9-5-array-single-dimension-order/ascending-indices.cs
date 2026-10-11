/*
Rules: E13-9-5-array-single-dimension-order; E13-9-1-form-foreach-iteration; E13-9-5-form-foreach; E13-9-5-array-collection-type; E13-9-5-array-enumerator-type; E13-9-5-array-iteration-type; E13-9-5-iteration-variable-declaration; E13-9-5-iteration-current-element; E13-9-5-alternative-implementation
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: foreach (int item in data)
Into: foreach (int item in new int[] { 3, 2, 1 })
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] data = new int[] { 1, 2, 3 };
        int trace = 0;
        foreach (int item in data) { trace = trace * 10 + item; }
        Check(trace == 123, "array-in-increasing-index-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
