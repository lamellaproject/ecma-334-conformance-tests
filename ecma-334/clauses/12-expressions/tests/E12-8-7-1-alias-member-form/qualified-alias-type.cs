/*
Rules: E12-8-7-1-alias-member-form
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Chosen::Worker.Value
Into: Chosen::Worker.Other
*/
using System;
using Chosen = Source;
namespace Source { public class Worker { public static int Value = 3, Other = 8; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Chosen::Worker.Value;
        Check(result == 3, "qualified-alias-member-is-member-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
