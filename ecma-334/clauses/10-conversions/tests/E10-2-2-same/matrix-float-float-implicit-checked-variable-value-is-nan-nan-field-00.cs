/*
Rules: E10-2-2-same
Authority: ECMA-334 7th ed 10.2.2
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
            float input = float.NaN;
            float result = checked(input);
            Check(float.IsNaN(result), "float-float-implicit-checked-variable-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
