/*
Rules: E14-5-4-extension-invocation-import
Authority: ECMA-334 7th ed 14.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using static Foreign.Extension;
Into: using static Foreign.Other;
*/
using System;
using static Foreign.Extension;
namespace Foreign
{
    static class Extension { public static int Next(this int value) { return value + 1; } }
    static class Other { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(28.Next() == 29, "extension-invocation-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
