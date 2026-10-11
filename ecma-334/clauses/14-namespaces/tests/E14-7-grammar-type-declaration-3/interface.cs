/*
Rules: E14-7-grammar-type-declaration-3
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: interface Marker {
Into: interface Different {
*/
using System;
interface Marker { int Code { get; } }
class Beacon : Marker { public int Code { get { return 29; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker value = new Beacon();
        Check(value.Code == 29, "declared-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
