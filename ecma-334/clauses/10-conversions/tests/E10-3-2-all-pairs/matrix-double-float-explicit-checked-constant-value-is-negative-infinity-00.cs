/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const double input = -1.7976931348623157e+308d;
            float result = checked((float)input);
            Check(float.IsNegativeInfinity(result), "double-float-explicit-checked-constant-0");
        }
        {
            const double input = -3.4028235999999999e+38d;
            float result = checked((float)input);
            Check(float.IsNegativeInfinity(result), "double-float-explicit-checked-constant-19");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
