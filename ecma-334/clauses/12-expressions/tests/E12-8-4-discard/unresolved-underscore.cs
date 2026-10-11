/*
Rules: E12-8-4-discard
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: _ = Next();
Into: missing = Next();
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next() { calls++; return 3; }
    static void Main()
    {
        _ = 3;
        _ = "label";
        _ = Next();
        Check(calls == 1, "unresolved-underscore-is-discard-without-shared-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
