/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 4
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
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-ulong-ulong-explicit-checked-lift-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==18446744073709551615UL, "nullable-ulong-ulong-explicit-checked-lift-1");
        }
        {
            ulong? input = 1UL;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==1UL, "nullable-ulong-ulong-explicit-checked-lift-2");
        }
        {
            ulong? input = 18446744073709551614UL;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==18446744073709551614UL, "nullable-ulong-ulong-explicit-checked-lift-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
