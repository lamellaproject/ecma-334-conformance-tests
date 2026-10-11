/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 13
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
            decimal input = 0m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-decimal-long-explicit-checked-wrap-2");
        }
        {
            decimal input = 1m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==1L, "nullable-decimal-long-explicit-checked-wrap-3");
        }
        {
            decimal input = -1m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==-1L, "nullable-decimal-long-explicit-checked-wrap-4");
        }
        {
            decimal input = 0.1m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-decimal-long-explicit-checked-wrap-5");
        }
        {
            decimal input = -0.1m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-decimal-long-explicit-checked-wrap-6");
        }
        {
            decimal input = 1E-28m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-decimal-long-explicit-checked-wrap-7");
        }
        {
            decimal input = -1E-28m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-decimal-long-explicit-checked-wrap-8");
        }
        {
            decimal input = -9223372036854775808m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==long.MinValue, "nullable-decimal-long-explicit-checked-wrap-10");
        }
        {
            decimal input = -9223372036854775807m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==-9223372036854775807L, "nullable-decimal-long-explicit-checked-wrap-11");
        }
        {
            decimal input = 9223372036854775806m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==9223372036854775806L, "nullable-decimal-long-explicit-checked-wrap-12");
        }
        {
            decimal input = 9223372036854775807m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==9223372036854775807L, "nullable-decimal-long-explicit-checked-wrap-13");
        }
        {
            decimal input = -9223372036854775808.75m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==long.MinValue, "nullable-decimal-long-explicit-checked-wrap-15");
        }
        {
            decimal input = 9223372036854775807.75m;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==9223372036854775807L, "nullable-decimal-long-explicit-checked-wrap-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
