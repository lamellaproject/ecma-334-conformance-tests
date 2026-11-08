/*
Rules: E8-3-8-decimal-width; E8-3-8-decimal-cmax-minimum; E8-3-8-decimal-emin-bound; E8-3-8-decimal-emax-bound
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: decimal tiny = 0.0000000000000000000000000001m;
Into: decimal tiny = 0m;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal tiny = 0.0000000000000000000000000001m;
        decimal high = 9999999999999999999999999999m;
        decimal fraction = 0.9999999999999999999999999999m;
        decimal unit = 1m, coefficient = 0m;
        for (int i = 0; i < 28; i++)
        {
            unit /= 10m;
            coefficient = coefficient * 10m + 9m;
        }
        Check(sizeof(decimal) == 16 && tiny == unit && tiny > 0m && -tiny < 0m && high == coefficient && -high == -coefficient && high > 0m && fraction == high * tiny && fraction > 0m && fraction < 1m, "decimal-required-width-and-domain");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
