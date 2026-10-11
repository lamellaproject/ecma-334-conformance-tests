/*
Rules: E8-3-8-decimal-width; E8-3-8-decimal-minimum-range; E8-3-8-decimal-cmax-minimum; E8-3-8-decimal-emin-bound; E8-3-8-decimal-emax-bound
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
        decimal high = 79000000000000000000000000000m;
        decimal integral = 10000000000000000000000000000m;
        Check(sizeof(decimal) == 16 && tiny > 0m && -tiny < 0m && high > integral && integral > 0m, "decimal-required-width-and-domain");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
