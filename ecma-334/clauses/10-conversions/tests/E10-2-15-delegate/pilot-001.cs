/*
Rules: E10-2-15-delegate; E10-7-1-delegate; E10-7-1-typed; E10-7-1-inferred; E10-7-1-value-expression; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Func<int,long> inferred=x=>x+2;
Into: Func<int,long> inferred=x=>x;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<int,long> explicitLambda=(int x)=>x+1;
        Func<int,long> inferred=x=>x+2;
        Func<int,long> method=delegate(int x){return x+3;};
        Check(explicitLambda(61)==62 && inferred(61)==63 && method(61)==64, "E10-2-15-delegate-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
