/*
Rules: E12-9-8-1-verbatim-await; E12-9-8-1-await-ordinary-outside
Authority: ECMA-334 7th ed 12.9.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int @await = 4
Into: int await = 4
*/
using System;
class Program
{
    static int captured;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Worker() { int @await = 4; captured = @await; }
    static void Main()
    {
        int await = 7; Worker();
        Check(captured == 4, "verbatim-inside-async"); Check(await == 7, "ordinary-outside-async");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
