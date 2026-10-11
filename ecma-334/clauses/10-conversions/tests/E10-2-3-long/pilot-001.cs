/*
Rules: E10-2-3-long
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: float a=x;
Into: float a=default(float);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long x = -317;
        float a=x; double b=x; decimal c=x;
        Check(a==-317 && b==-317 && c==-317, "E10-2-3-long-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
