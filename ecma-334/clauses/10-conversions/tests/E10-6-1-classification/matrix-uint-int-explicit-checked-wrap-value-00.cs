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
            uint input = 0U;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-uint-int-explicit-checked-wrap-0");
        }
        {
            uint input = 1U;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==1, "nullable-uint-int-explicit-checked-wrap-2");
        }
        {
            uint input = 2147483646U;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==2147483646, "nullable-uint-int-explicit-checked-wrap-3");
        }
        {
            uint input = 2147483647U;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==2147483647, "nullable-uint-int-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
