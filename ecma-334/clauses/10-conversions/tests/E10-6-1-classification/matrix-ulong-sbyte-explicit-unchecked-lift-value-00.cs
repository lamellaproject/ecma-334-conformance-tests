/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 6
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
            ulong? input = 0UL;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-ulong-sbyte-explicit-unchecked-lift-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-ulong-sbyte-explicit-unchecked-lift-1");
        }
        {
            ulong? input = 1UL;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-ulong-sbyte-explicit-unchecked-lift-2");
        }
        {
            ulong? input = 126UL;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-ulong-sbyte-explicit-unchecked-lift-3");
        }
        {
            ulong? input = 127UL;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-ulong-sbyte-explicit-unchecked-lift-4");
        }
        {
            ulong? input = 128UL;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-ulong-sbyte-explicit-unchecked-lift-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
