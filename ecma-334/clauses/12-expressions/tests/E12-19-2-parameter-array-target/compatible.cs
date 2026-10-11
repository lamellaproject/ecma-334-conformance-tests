/*
Rules: E12-19-2-parameter-array-target
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: params int[] values
Into: int[] values
*/
using System;
delegate int Sum(params int[] values);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sum function = (int[] items) => { int sum = 0; for (int i = 0; i < items.Length; i++) sum += items[i]; return sum; };
        Check(function(3, 7, 11) == 21, "target-parameter-array-expands-at-invocation");
        Check(function() == 0, "target-parameter-array-allows-empty-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
