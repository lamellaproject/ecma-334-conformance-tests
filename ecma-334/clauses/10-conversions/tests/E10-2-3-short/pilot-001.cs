/*
Rules: E10-2-3-short; E10-2-3-exact
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int a=x;
Into: int a=default(int);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        short x = -23017;
        int a=x; long b=x; float c=x; double d=x; decimal e=x;
        Check(a==-23017 && b==-23017 && c==-23017 && d==-23017 && e==-23017, "E10-2-3-short-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
