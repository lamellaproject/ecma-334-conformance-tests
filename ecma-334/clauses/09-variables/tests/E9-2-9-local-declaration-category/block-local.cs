/*
Rules: E9-2-9-local-declaration-category; E9-2-9-declaration-in-block
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int cell = 26;
Into: int cell = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 26;
        Check(cell == 26, "local-declaration-in-block");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
