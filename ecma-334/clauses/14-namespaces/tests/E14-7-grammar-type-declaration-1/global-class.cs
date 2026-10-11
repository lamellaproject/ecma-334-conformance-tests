/*
Rules: E14-7-grammar-type-declaration-1; E14-2-program-compilation-units; E14-2-single-global-namespace; E14-6-grammar-namespace-member-declaration-2; E14-6-unit-member-declaration; E14-7-type-at-unit-level; E14-7-top-level-qualified-name
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Beacon {
Into: class Different {
*/
using System;
class Beacon { public const int Code = 29; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(global::Beacon.Code == 29, "unit-level-class-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
