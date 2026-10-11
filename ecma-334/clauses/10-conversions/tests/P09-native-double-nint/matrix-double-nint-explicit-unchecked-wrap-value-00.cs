/*
Rules: P09-native-double-nint; P09-native-nullable-wrap
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
            double input = 0.0d;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "double-nint-explicit-unchecked-wrap-2");
        }
        {
            double input = -0.0d;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "double-nint-explicit-unchecked-wrap-3");
        }
        {
            double input = 1.0d;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==1L, "double-nint-explicit-unchecked-wrap-4");
        }
        {
            double input = -1.0d;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==-1L, "double-nint-explicit-unchecked-wrap-5");
        }
        {
            double input = 0.75d;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "double-nint-explicit-unchecked-wrap-6");
        }
        {
            double input = -0.75d;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "double-nint-explicit-unchecked-wrap-7");
        }
        {
            double input = -9.2233720368547758e+18d;
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==long.MinValue, "double-nint-explicit-unchecked-wrap-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
