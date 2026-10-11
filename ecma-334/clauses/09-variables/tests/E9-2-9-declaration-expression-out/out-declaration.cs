/*
Rules: E9-2-9-declaration-expression-out; E9-2-9-declaration-expression-category
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: value = 69;
Into: value = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Fill(out int value) { value = 69; }
    static void Main()
    {
        Fill(out int cell);
        Check(cell == 69, "out-declaration-introduces-local");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
