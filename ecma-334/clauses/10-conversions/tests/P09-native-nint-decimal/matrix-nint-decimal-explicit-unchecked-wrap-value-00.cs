/*
Rules: P09-native-nint-decimal; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
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
            nint input = (nint)(long.MinValue);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==-9223372036854775808m, "nint-decimal-explicit-unchecked-wrap-0");
        }
        {
            nint input = (nint)(9223372036854775807L);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==9223372036854775807m, "nint-decimal-explicit-unchecked-wrap-1");
        }
        {
            nint input = (nint)(0L);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==0m, "nint-decimal-explicit-unchecked-wrap-2");
        }
        {
            nint input = (nint)(1L);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==1m, "nint-decimal-explicit-unchecked-wrap-3");
        }
        {
            nint input = (nint)(-1L);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==-1m, "nint-decimal-explicit-unchecked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
