/*
Rules: E12-6-4-2-generic-constraints
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick("x")
Into: Pick(3)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick<T>(T x) where T : struct { return 1; }
    static int Pick(object x) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick("x") == 2, "inferred-string-violates-struct-and-excludes-generic-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
