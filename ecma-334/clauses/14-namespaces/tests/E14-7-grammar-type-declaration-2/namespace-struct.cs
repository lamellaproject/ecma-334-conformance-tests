/*
Rules: E14-7-grammar-type-declaration-2; E14-7-type-in-namespace; E14-7-member-qualified-name
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: struct Parcel {
Into: struct Different {
*/
using System;
namespace Harbor { struct Parcel { public int Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Harbor.Parcel value;
        value.Value = 29;
        Check(value.Value == 29, "namespace-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
