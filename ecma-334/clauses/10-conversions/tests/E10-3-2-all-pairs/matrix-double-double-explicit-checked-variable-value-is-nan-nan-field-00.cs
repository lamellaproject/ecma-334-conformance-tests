/*
Rules: E10-3-2-all-pairs
Authority: ECMA-334 7th ed 10.3.2
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
            double result = checked((double)input);
            Check(double.IsNaN(result), "double-double-explicit-checked-variable-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
