/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            ushort? input = (ushort)(0);
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-ushort-sbyte-explicit-checked-lift-0");
        }
        {
            ushort? input = (ushort)(1);
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-ushort-sbyte-explicit-checked-lift-2");
        }
        {
            ushort? input = (ushort)(126);
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-ushort-sbyte-explicit-checked-lift-3");
        }
        {
            ushort? input = (ushort)(127);
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-ushort-sbyte-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
