/*
Rules: P09-native-decimal-nuint; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 10
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
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "decimal-nuint-explicit-checked-wrap-2");
        }
        {
            decimal input = 1m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==1UL, "decimal-nuint-explicit-checked-wrap-3");
        }
        {
            decimal input = 0.1m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "decimal-nuint-explicit-checked-wrap-5");
        }
        {
            decimal input = -0.1m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "decimal-nuint-explicit-checked-wrap-6");
        }
        {
            decimal input = 1E-28m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "decimal-nuint-explicit-checked-wrap-7");
        }
        {
            decimal input = -1E-28m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "decimal-nuint-explicit-checked-wrap-8");
        }
        {
            decimal input = 18446744073709551614m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==18446744073709551614UL, "decimal-nuint-explicit-checked-wrap-9");
        }
        {
            decimal input = 18446744073709551615m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==18446744073709551615UL, "decimal-nuint-explicit-checked-wrap-10");
        }
        {
            decimal input = -0.75m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "decimal-nuint-explicit-checked-wrap-12");
        }
        {
            decimal input = 18446744073709551615.75m;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==18446744073709551615UL, "decimal-nuint-explicit-checked-wrap-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
