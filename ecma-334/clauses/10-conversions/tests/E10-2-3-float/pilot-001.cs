/*
Rules: E10-2-3-float; E10-2-3-exact
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: double y=x;
Into: double y=default(double);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float x = 13.375f; double y=x;
        Check(y == 13.375d && (float)y == x, "E10-2-3-float-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
