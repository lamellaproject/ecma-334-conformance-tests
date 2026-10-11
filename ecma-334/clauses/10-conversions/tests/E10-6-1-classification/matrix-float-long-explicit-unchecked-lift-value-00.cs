/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 7
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
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-float-long-explicit-unchecked-lift-2");
        }
        {
            float? input = -0.0f;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-float-long-explicit-unchecked-lift-3");
        }
        {
            float? input = 1.0f;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==1L, "nullable-float-long-explicit-unchecked-lift-4");
        }
        {
            float? input = -1.0f;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==-1L, "nullable-float-long-explicit-unchecked-lift-5");
        }
        {
            float? input = 0.75f;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-float-long-explicit-unchecked-lift-6");
        }
        {
            float? input = -0.75f;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-float-long-explicit-unchecked-lift-7");
        }
        {
            float? input = -9.22337204e+18f;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==long.MinValue, "nullable-float-long-explicit-unchecked-lift-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
