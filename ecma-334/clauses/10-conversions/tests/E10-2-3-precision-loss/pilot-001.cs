/*
Rules: E10-2-3-precision-loss
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int i=16777217;
Into: int i=default(int);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int i=16777217; uint u=16777217;
        long l=9007199254740993L; ulong ul=9007199254740993UL;
        float fi=i, fu=u, fl=l, ful=ul; double dl=l, dul=ul;
        Check(fi==16777216f && fu==16777216f && fl==9007199254740992f && ful==9007199254740992f, "E10-2-3-precision-loss-pilot-001-check-01");
        Check(dl==9007199254740992d && dul==9007199254740992d, "E10-2-3-precision-loss-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
