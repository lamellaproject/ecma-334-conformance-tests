/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 2
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
            double? input = -1.7976931348623157e+308d;
            float result = unchecked((float)input);
            Check(float.IsNegativeInfinity(result), "nullable-double-float-explicit-unchecked-unwrap-0");
        }
        {
            double? input = -3.4028235999999999e+38d;
            float result = unchecked((float)input);
            Check(float.IsNegativeInfinity(result), "nullable-double-float-explicit-unchecked-unwrap-19");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
