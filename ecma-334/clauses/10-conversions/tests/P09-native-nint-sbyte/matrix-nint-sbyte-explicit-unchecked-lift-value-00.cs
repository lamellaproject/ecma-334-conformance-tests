/*
Rules: P09-native-nint-sbyte; P09-native-nullable-lift
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 11
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            nint? input = (nint)(long.MinValue);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nint-sbyte-explicit-unchecked-lift-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nint-sbyte-explicit-unchecked-lift-1");
        }
        {
            nint? input = (nint)(0L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nint-sbyte-explicit-unchecked-lift-2");
        }
        {
            nint? input = (nint)(1L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nint-sbyte-explicit-unchecked-lift-3");
        }
        {
            nint? input = (nint)(-1L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nint-sbyte-explicit-unchecked-lift-4");
        }
        {
            nint? input = (nint)(-129L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nint-sbyte-explicit-unchecked-lift-5");
        }
        {
            nint? input = (nint)(-128L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nint-sbyte-explicit-unchecked-lift-6");
        }
        {
            nint? input = (nint)(-127L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-127), "nint-sbyte-explicit-unchecked-lift-7");
        }
        {
            nint? input = (nint)(126L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nint-sbyte-explicit-unchecked-lift-8");
        }
        {
            nint? input = (nint)(127L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nint-sbyte-explicit-unchecked-lift-9");
        }
        {
            nint? input = (nint)(128L);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nint-sbyte-explicit-unchecked-lift-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
