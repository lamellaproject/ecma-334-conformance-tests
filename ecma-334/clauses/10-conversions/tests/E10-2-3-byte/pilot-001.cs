/*
Rules: E10-2-3-byte; E10-2-3-exact; E10-2-1-categories
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
        byte x = 211;
        short a=x; ushort b=x; int c=x; uint d=x; long e=x; ulong f=x; float g=x; double h=x; decimal i=x;
        Check(a==211 && b==211 && c==211 && d==211 && e==211 && f==211 && g==211 && h==211 && i==211, "E10-2-3-byte-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
