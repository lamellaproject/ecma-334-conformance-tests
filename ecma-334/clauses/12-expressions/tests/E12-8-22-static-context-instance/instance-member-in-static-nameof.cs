/*
Rules: E12-8-22-static-context-instance; E12-8-22-compile-time-lookup
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(Number)
Into: nameof(Other)
*/
using System;
class Program
{
    int Number, Other;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const string name = nameof(Number);
        Check(name == "Number", "static-nameof-can-name-instance-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
