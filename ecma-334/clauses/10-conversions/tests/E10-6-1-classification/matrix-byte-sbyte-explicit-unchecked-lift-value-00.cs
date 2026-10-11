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
            byte? input = (byte)(0);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-byte-sbyte-explicit-unchecked-lift-0");
        }
        {
            byte? input = (byte)(255);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-byte-sbyte-explicit-unchecked-lift-1");
        }
        {
            byte? input = (byte)(1);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-byte-sbyte-explicit-unchecked-lift-2");
        }
        {
            byte? input = (byte)(126);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-byte-sbyte-explicit-unchecked-lift-3");
        }
        {
            byte? input = (byte)(127);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-byte-sbyte-explicit-unchecked-lift-4");
        }
        {
            byte? input = (byte)(128);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-byte-sbyte-explicit-unchecked-lift-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
