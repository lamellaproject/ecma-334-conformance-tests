/*
Rules: E10-3-2-double-float-round; E10-3-2-double-float-small; E10-3-2-double-float-large; E10-3-2-double-float-nan
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: float rounded=(float)tie, zero=(float)tiny, infinity=(float)huge, result=(float)nan;
Into: float rounded=default(float), zero=(float)tiny, infinity=(float)huge, result=(float)nan;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double tie=1.000000059604644775390625d;
        double tiny=-1e-300, huge=-1e300, nan=double.NaN;
        float rounded=(float)tie, zero=(float)tiny, infinity=(float)huge, result=(float)nan;
        Check(rounded==1f && zero==0f && float.IsNegativeInfinity(1f/zero), "E10-3-2-double-float-round-pilot-001-check-01");
        Check(float.IsNegativeInfinity(infinity) && float.IsNaN(result), "E10-3-2-double-float-round-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
