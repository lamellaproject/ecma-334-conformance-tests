/*
Rules: E15-4-constant-reference
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const Reader Empty = null;
Into: public const Reader Other = null;
*/
using System;
delegate int Reader();
class Limits { public const Reader Empty = null; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Reader value = Limits.Empty;
        Check(value == null, "delegate-constant-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
