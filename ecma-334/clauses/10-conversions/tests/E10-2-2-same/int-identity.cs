/*
Rules: E10-2-2-same; E10-2-2-no-effect
Authority: ECMA-334 7th ed 10.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int result = input;
Into: int result = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input = 61;
        int result = input;
        Check(result == 61, "int-identity/value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
