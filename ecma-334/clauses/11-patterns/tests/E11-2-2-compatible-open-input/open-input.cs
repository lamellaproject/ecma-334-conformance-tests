/*
Rules: E11-2-2-compatible-open-input
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: input is int value
Into: input is long value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Find<T>(T input) { if (input is int value) return value; return -1; }
    static void Main()
    {
        Check(Find<int>(29) == 29, "open-input-match");
        Check(Find<string>("harbor") == -1, "open-input-no-match");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
