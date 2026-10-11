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
            sbyte? input = (sbyte)(127);
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==127UL, "nullable-sbyte-ulong-explicit-checked-lift-1");
        }
        {
            sbyte? input = (sbyte)(0);
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-sbyte-ulong-explicit-checked-lift-2");
        }
        {
            sbyte? input = (sbyte)(1);
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==1UL, "nullable-sbyte-ulong-explicit-checked-lift-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
