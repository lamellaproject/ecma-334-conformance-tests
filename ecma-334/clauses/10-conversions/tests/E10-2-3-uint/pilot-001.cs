/*
Rules: E10-2-3-uint
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: long a=x;
Into: long a=default(long);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        uint x = 317;
        long a=x; ulong b=x; float c=x; double d=x; decimal e=x;
        Check(a==317 && b==317 && c==317 && d==317 && e==317, "E10-2-3-uint-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
