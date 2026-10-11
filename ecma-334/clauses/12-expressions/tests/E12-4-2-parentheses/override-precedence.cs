/*
Rules: E12-4-2-parentheses
Authority: ECMA-334 7th ed 12.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (a - b) * c
Into: a - b * c
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int a = 29, b = 8, c = 5; int result = (a - b) * c;
        Check(result == 105, "parentheses-control-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
