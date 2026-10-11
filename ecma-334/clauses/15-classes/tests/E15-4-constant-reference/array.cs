/*
Rules: E15-4-constant-reference
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int[] Empty = null;
Into: public const int[] Other = null;
*/
using System;
class Limits { public const int[] Empty = null; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] value = Limits.Empty;
        Check(value == null, "array-constant-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
