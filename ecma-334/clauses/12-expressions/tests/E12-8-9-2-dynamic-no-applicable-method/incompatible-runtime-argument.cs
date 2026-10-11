/*
Rules: E12-8-9-2-dynamic-no-applicable-method
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic argument = "fir";
Into: dynamic argument = 3;
*/
using System;
class Program
{
    static int checks, failures;
    static void Choose(int value) { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = "fir";
        bool rejected = false;
        try { Choose(argument); }
        catch (Exception) { rejected = true; }
        Check(rejected, "no-applicable-runtime-method-binding-error");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
