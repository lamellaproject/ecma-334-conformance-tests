/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            ulong input = 0UL;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-ulong-long-explicit-checked-wrap-0");
        }
        {
            ulong input = 1UL;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==1L, "nullable-ulong-long-explicit-checked-wrap-2");
        }
        {
            ulong input = 9223372036854775806UL;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==9223372036854775806L, "nullable-ulong-long-explicit-checked-wrap-3");
        }
        {
            ulong input = 9223372036854775807UL;
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==9223372036854775807L, "nullable-ulong-long-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
