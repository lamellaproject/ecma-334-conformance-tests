/*
Rules: E15-4-constant-long
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const long Code = -9000000001L;
Into: public const long Code = -9000000000L;
*/
using System;
class Limits { public const long Code = -9000000001L; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(long value) { return 1; }
    static int Kind(decimal value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "long-constant-type");
        Check(Limits.Code == -9000000001L, "long-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
