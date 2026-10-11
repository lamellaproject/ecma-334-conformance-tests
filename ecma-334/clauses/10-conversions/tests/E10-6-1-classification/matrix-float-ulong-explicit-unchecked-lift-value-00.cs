/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            float? input = 0.0f;
            ulong? result = unchecked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-float-ulong-explicit-unchecked-lift-2");
        }
        {
            float? input = -0.0f;
            ulong? result = unchecked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-float-ulong-explicit-unchecked-lift-3");
        }
        {
            float? input = 1.0f;
            ulong? result = unchecked((ulong?)input);
            Check(result.HasValue && result.Value==1UL, "nullable-float-ulong-explicit-unchecked-lift-4");
        }
        {
            float? input = 0.75f;
            ulong? result = unchecked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-float-ulong-explicit-unchecked-lift-6");
        }
        {
            float? input = -0.75f;
            ulong? result = unchecked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-float-ulong-explicit-unchecked-lift-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
