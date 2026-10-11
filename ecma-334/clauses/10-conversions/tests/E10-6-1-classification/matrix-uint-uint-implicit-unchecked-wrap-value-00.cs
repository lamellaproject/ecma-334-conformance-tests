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
            uint? result = unchecked(input);
            Check(result.HasValue && result.Value==0U, "nullable-uint-uint-implicit-unchecked-wrap-0");
        }
        {
            uint input = 4294967295U;
            uint? result = unchecked(input);
            Check(result.HasValue && result.Value==4294967295U, "nullable-uint-uint-implicit-unchecked-wrap-1");
        }
        {
            uint input = 1U;
            uint? result = unchecked(input);
            Check(result.HasValue && result.Value==1U, "nullable-uint-uint-implicit-unchecked-wrap-2");
        }
        {
            uint input = 4294967294U;
            uint? result = unchecked(input);
            Check(result.HasValue && result.Value==4294967294U, "nullable-uint-uint-implicit-unchecked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
