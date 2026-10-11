/*
Rules: P09-native-decimal-nint; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 13
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
            decimal input = 0m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "decimal-nint-explicit-checked-wrap-2");
        }
        {
            decimal input = 1m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==1L, "decimal-nint-explicit-checked-wrap-3");
        }
        {
            decimal input = -1m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==-1L, "decimal-nint-explicit-checked-wrap-4");
        }
        {
            decimal input = 0.1m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "decimal-nint-explicit-checked-wrap-5");
        }
        {
            decimal input = -0.1m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "decimal-nint-explicit-checked-wrap-6");
        }
        {
            decimal input = 1E-28m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "decimal-nint-explicit-checked-wrap-7");
        }
        {
            decimal input = -1E-28m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "decimal-nint-explicit-checked-wrap-8");
        }
        {
            decimal input = -9223372036854775808m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==long.MinValue, "decimal-nint-explicit-checked-wrap-10");
        }
        {
            decimal input = -9223372036854775807m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==-9223372036854775807L, "decimal-nint-explicit-checked-wrap-11");
        }
        {
            decimal input = 9223372036854775806m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==9223372036854775806L, "decimal-nint-explicit-checked-wrap-12");
        }
        {
            decimal input = 9223372036854775807m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==9223372036854775807L, "decimal-nint-explicit-checked-wrap-13");
        }
        {
            decimal input = -9223372036854775808.75m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==long.MinValue, "decimal-nint-explicit-checked-wrap-15");
        }
        {
            decimal input = 9223372036854775807.75m;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==9223372036854775807L, "decimal-nint-explicit-checked-wrap-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
