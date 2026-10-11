/*
Rules: E11-2-2-compatible-identity; E11-2-1-applicability-definition; E11-2-2-declaration-applicability
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: source is int value
Into: source is string value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int source = 29;
        int answer = -1;
        if (source is int value) answer = value;
        Check(answer == 29, "identity-compatible");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
