/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 1
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
            double input = double.NaN;
            double? result = unchecked((double?)input);
            Check(result.HasValue && double.IsNaN(result.Value), "nullable-double-double-explicit-unchecked-wrap-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
