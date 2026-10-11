/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            ulong? input = 0UL;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==0m, "nullable-ulong-decimal-implicit-checked-lift-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==18446744073709551615m, "nullable-ulong-decimal-implicit-checked-lift-1");
        }
        {
            ulong? input = 1UL;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==1m, "nullable-ulong-decimal-implicit-checked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
