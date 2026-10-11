/*
Rules: P09-native-long-nint; P09-native-nullable-lift
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
            long? input = long.MinValue;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==long.MinValue, "long-nint-explicit-unchecked-lift-0");
        }
        {
            long? input = 9223372036854775807L;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==9223372036854775807L, "long-nint-explicit-unchecked-lift-1");
        }
        {
            long? input = 0L;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "long-nint-explicit-unchecked-lift-2");
        }
        {
            long? input = 1L;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==1L, "long-nint-explicit-unchecked-lift-3");
        }
        {
            long? input = -1L;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==-1L, "long-nint-explicit-unchecked-lift-4");
        }
        {
            long? input = -9223372036854775807L;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==-9223372036854775807L, "long-nint-explicit-unchecked-lift-5");
        }
        {
            long? input = 9223372036854775806L;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==9223372036854775806L, "long-nint-explicit-unchecked-lift-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
