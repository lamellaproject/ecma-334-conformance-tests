/*
Rules: E15-4-constant-int
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const int Code = -123456789;
Into: public const int Code = -123456788;
*/
using System;
class Limits { public const int Code = -123456789; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(int value) { return 1; }
    static int Kind(long value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "int-constant-type");
        Check(Limits.Code == -123456789, "int-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
