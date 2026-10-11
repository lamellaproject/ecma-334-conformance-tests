/*
Rules: E14-5-4-import-nested-types; E14-5-1-grammar-using-directive-3; E14-5-4-grammar-using-static-directive-1
Authority: ECMA-334 7th ed 14.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using static First;
Into: using static Second;
*/
using System;
using static First;
class First { public class Nested { public const int Code = 29; } }
class Second { public class Nested { public const int Code = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Nested.Code == 29, "direct-nested-type-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
