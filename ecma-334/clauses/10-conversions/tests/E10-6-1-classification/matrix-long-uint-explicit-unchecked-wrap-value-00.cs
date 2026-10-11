/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 8
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
            long input = long.MinValue;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-long-uint-explicit-unchecked-wrap-0");
        }
        {
            long input = 9223372036854775807L;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nullable-long-uint-explicit-unchecked-wrap-1");
        }
        {
            long input = 0L;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-long-uint-explicit-unchecked-wrap-2");
        }
        {
            long input = 1L;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==1U, "nullable-long-uint-explicit-unchecked-wrap-3");
        }
        {
            long input = -1L;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nullable-long-uint-explicit-unchecked-wrap-4");
        }
        {
            long input = 4294967294L;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==4294967294U, "nullable-long-uint-explicit-unchecked-wrap-5");
        }
        {
            long input = 4294967295L;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nullable-long-uint-explicit-unchecked-wrap-6");
        }
        {
            long input = 4294967296L;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-long-uint-explicit-unchecked-wrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
