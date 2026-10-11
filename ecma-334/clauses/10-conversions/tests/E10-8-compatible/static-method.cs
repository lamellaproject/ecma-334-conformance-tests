/*
Rules: E10-8-compatible; E10-8-result
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Func<int> converted = Read;
Into: Func<int> converted = Wrong;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read() { return 61; }
    static int Wrong() { return 0; }
    static void Main()
    {
        Func<int> converted = Read;
        Check(converted() == 61, "static-method/selected-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
