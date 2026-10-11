/*
Rules: E12-6-4-2-normal-form
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Read(new int[] { 4, 8 })
Into: Read(4)
*/
using System;
class Program
{
    static int checks, failures;
    static int Read(params int[] values) { return values.Length * 100 + values[0]; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(new int[] { 4, 8 }) == 204, "array-argument-binds-in-normal-form");
        Check(Read(values: new int[] { 9, 3, 5 }) == 309, "named-array-argument-binds-in-normal-form");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
