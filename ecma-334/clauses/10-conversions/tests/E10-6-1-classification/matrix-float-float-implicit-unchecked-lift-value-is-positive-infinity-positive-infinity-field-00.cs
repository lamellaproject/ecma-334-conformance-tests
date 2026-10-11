/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            float? input = float.PositiveInfinity;
            float? result = unchecked(input);
            Check(result.HasValue && float.IsPositiveInfinity(result.Value), "nullable-float-float-implicit-unchecked-lift-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
