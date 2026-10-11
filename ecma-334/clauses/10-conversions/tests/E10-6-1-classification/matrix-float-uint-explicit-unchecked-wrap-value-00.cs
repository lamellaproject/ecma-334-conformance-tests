/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            float input = 0.0f;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-float-uint-explicit-unchecked-wrap-2");
        }
        {
            float input = -0.0f;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-float-uint-explicit-unchecked-wrap-3");
        }
        {
            float input = 1.0f;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==1U, "nullable-float-uint-explicit-unchecked-wrap-4");
        }
        {
            float input = 0.75f;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-float-uint-explicit-unchecked-wrap-6");
        }
        {
            float input = -0.75f;
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-float-uint-explicit-unchecked-wrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
