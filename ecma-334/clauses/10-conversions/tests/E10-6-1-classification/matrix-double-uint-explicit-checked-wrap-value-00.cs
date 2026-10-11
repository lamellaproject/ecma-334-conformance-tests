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
            double input = 0.0d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-double-uint-explicit-checked-wrap-2");
        }
        {
            double input = -0.0d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-double-uint-explicit-checked-wrap-3");
        }
        {
            double input = 1.0d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==1U, "nullable-double-uint-explicit-checked-wrap-4");
        }
        {
            double input = 0.75d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-double-uint-explicit-checked-wrap-6");
        }
        {
            double input = -0.75d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-double-uint-explicit-checked-wrap-7");
        }
        {
            double input = 4294967294.0d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==4294967294U, "nullable-double-uint-explicit-checked-wrap-11");
        }
        {
            double input = 4294967295.0d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nullable-double-uint-explicit-checked-wrap-12");
        }
        {
            double input = 4294967295.75d;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nullable-double-uint-explicit-checked-wrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
