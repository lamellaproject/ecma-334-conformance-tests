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
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-ulong-uint-explicit-checked-lift-0");
        }
        {
            ulong? input = 1UL;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==1U, "nullable-ulong-uint-explicit-checked-lift-2");
        }
        {
            ulong? input = 4294967294UL;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==4294967294U, "nullable-ulong-uint-explicit-checked-lift-3");
        }
        {
            ulong? input = 4294967295UL;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nullable-ulong-uint-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
