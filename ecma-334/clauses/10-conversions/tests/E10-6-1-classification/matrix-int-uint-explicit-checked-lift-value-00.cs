/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            int? input = 2147483647;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==2147483647U, "nullable-int-uint-explicit-checked-lift-1");
        }
        {
            int? input = 0;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nullable-int-uint-explicit-checked-lift-2");
        }
        {
            int? input = 1;
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==1U, "nullable-int-uint-explicit-checked-lift-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
