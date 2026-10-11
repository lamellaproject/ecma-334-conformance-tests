/*
Rules: P09-native-float-nint; P09-native-nullable-lift
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
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
            float? input = 0.0f;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "float-nint-explicit-unchecked-lift-2");
        }
        {
            float? input = -0.0f;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "float-nint-explicit-unchecked-lift-3");
        }
        {
            float? input = 1.0f;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==1L, "float-nint-explicit-unchecked-lift-4");
        }
        {
            float? input = -1.0f;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==-1L, "float-nint-explicit-unchecked-lift-5");
        }
        {
            float? input = 0.75f;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "float-nint-explicit-unchecked-lift-6");
        }
        {
            float? input = -0.75f;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "float-nint-explicit-unchecked-lift-7");
        }
        {
            float? input = -9.22337204e+18f;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==long.MinValue, "float-nint-explicit-unchecked-lift-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
