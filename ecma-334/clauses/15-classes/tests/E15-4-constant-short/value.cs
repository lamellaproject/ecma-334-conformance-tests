/*
Rules: E15-4-constant-short
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const short Code = -30101;
Into: public const short Code = -30100;
*/
using System;
class Limits { public const short Code = -30101; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(short value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "short-constant-type");
        Check(Limits.Code == -30101, "short-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
