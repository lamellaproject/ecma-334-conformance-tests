/*
Rules: E10-2-3-sbyte; E10-2-3-exact
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: short a=x;
Into: short a=default(short);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte x = -91;
        short a=x; int b=x; long c=x; float d=x; double e=x; decimal f=x;
        Check(a==-91 && b==-91 && c==-91 && d==-91 && e==-91 && f==-91, "E10-2-3-sbyte-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
