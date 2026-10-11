/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            float input = 0.0f;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-float-int-explicit-unchecked-wrap-2");
        }
        {
            float input = -0.0f;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-float-int-explicit-unchecked-wrap-3");
        }
        {
            float input = 1.0f;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==1, "nullable-float-int-explicit-unchecked-wrap-4");
        }
        {
            float input = -1.0f;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-1, "nullable-float-int-explicit-unchecked-wrap-5");
        }
        {
            float input = 0.75f;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-float-int-explicit-unchecked-wrap-6");
        }
        {
            float input = -0.75f;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-float-int-explicit-unchecked-wrap-7");
        }
        {
            float input = -2.14748365e+09f;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-2147483648, "nullable-float-int-explicit-unchecked-wrap-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
