/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            uint input = 0U;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-uint-long-explicit-unchecked-wrap-0");
        }
        {
            uint input = 4294967295U;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==4294967295L, "nullable-uint-long-explicit-unchecked-wrap-1");
        }
        {
            uint input = 1U;
            long? result = unchecked((long?)input);
            Check(result.HasValue && result.Value==1L, "nullable-uint-long-explicit-unchecked-wrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
