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
            double? input = 0.0d;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-double-long-explicit-unchecked-lift-2");
        }
        {
            double? input = -0.0d;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-double-long-explicit-unchecked-lift-3");
        }
        {
            double? input = 1.0d;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==1L, "nullable-double-long-explicit-unchecked-lift-4");
        }
        {
            double? input = -1.0d;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==-1L, "nullable-double-long-explicit-unchecked-lift-5");
        }
        {
            double? input = 0.75d;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-double-long-explicit-unchecked-lift-6");
        }
        {
            double? input = -0.75d;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-double-long-explicit-unchecked-lift-7");
        }
        {
            double? input = -9.2233720368547758e+18d;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==long.MinValue, "nullable-double-long-explicit-unchecked-lift-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
