/*
Rules: E10-2-3-ushort; E10-2-3-exact
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
        ushort x = 53017;
        int a=x; uint b=x; long c=x; ulong d=x; float e=x; double f=x; decimal g=x;
        Check(a==53017 && b==53017 && c==53017 && d==53017 && e==53017 && f==53017 && g==53017, "E10-2-3-ushort-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
