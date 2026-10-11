/*
Rules: E15-2-5-class-constraint-arrays
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : class
Into: where T : struct
*/
using System;
class Program
{
    static T Echo<T>(T value) where T : class { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] item = new int[] { 137 };
        Check(Echo<int[]>(item) == item, "array-type-satisfies-reference-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
