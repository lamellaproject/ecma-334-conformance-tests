/*
Rules: E14-5-4-import-static-members
Authority: ECMA-334 7th ed 14.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using static First;
Into: using static Second;
*/
using System;
using static First;
class First { public const int Code = 29; }
class Second { public const int Code = 31; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Code == 29, "direct-static-member-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
