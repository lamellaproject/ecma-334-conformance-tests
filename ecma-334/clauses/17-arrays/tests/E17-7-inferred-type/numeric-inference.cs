/*
Rules: E17-7-inferred-type
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new[] { 4, 21L }
Into: new[] { 4, 21 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var inferred = new[] { 4, 21L };
        long[] values = inferred;
        Check(values.Length == 2, "inferred-long-array");
        Check(values[0] == 4 && values[1] == 21, "inferred-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
