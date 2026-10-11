/*
Rules: E10-2-11-int; E10-2-11-long; E12-23-constant-conversion; E12-23-identity; E12-23-numeric; E12-23-enum; E12-23-constant; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int Basis=(int) (Label)61;
Into: int Basis=default(int);
*/
using System;

enum Label { Token=61 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const int Basis=(int) (Label)61;
        const int Same=(int)Basis;
        sbyte a=Same; byte b=Same; short c=Same; ushort d=Same; uint e=Same; ulong f=Same;
        const long Wide=9223372036854775807L; ulong g=Wide;
        Check(a==61 && b==61 && c==61 && d==61 && e==61 && f==61 && g==9223372036854775807UL, "E10-2-11-int-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
