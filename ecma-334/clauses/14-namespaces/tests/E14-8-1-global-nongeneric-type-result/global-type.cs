/*
Rules: E14-8-1-global-nongeneric-type-result
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: global::Beacon.Code
Into: global::Other.Code
*/
using System;
class Beacon { public const int Code = 29; }
class Other { public const int Code = 31; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(global::Beacon.Code == 29, "global-nongeneric-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
