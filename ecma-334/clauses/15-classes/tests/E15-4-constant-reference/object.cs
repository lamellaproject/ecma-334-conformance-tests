/*
Rules: E15-4-constant-reference
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const object Empty = null;
Into: public const object Other = null;
*/
using System;
class Limits { public const object Empty = null; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object value = Limits.Empty;
        Check(value == null, "object-constant-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
