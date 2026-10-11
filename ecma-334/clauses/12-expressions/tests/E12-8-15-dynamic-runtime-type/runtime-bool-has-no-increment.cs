/*
Rules: E12-8-15-dynamic-runtime-type
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic value = true;
Into: dynamic value = 4;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic value = true; bool rejected = false;
        try { value++; } catch (Exception) { rejected = true; }
        Check(rejected, "dynamic-bool-cannot-use-predefined-increment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
