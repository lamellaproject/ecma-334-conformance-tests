/*
Rules: E12-8-9-2-dynamic-ambiguous-overload
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic second = 5;
Into: dynamic second = 5L;
*/
using System;
class Program
{
    static int checks, failures;
    static void Choose(int first, long second) { }
    static void Choose(long first, int second) { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic second = 5;
        bool rejected = false;
        try { Choose(3, second); }
        catch (Exception) { rejected = true; }
        Check(rejected, "ambiguous-runtime-overload-binding-error");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
