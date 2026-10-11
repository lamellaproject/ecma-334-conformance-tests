/*
Rules: E10-3-2-decimal-float-round; E10-3-2-decimal-float-special; E10-3-2-decimal-float-no-throw
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: float rounded=(float)fractional, bounded=(float)maximum;
Into: float rounded=default(float), bounded=(float)maximum;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal fractional=16777217m, maximum=decimal.MaxValue;
        float rounded=(float)fractional, bounded=(float)maximum; double wide=(double)maximum;
        Check(rounded==16777216f && bounded>0 && !float.IsInfinity(bounded) && !double.IsInfinity(wide), "E10-3-2-decimal-float-round-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
