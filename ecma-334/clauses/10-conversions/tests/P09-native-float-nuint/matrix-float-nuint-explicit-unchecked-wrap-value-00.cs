/*
Rules: P09-native-float-nuint; P09-native-nullable-wrap
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
            float input = 0.0f;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "float-nuint-explicit-unchecked-wrap-2");
        }
        {
            float input = -0.0f;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "float-nuint-explicit-unchecked-wrap-3");
        }
        {
            float input = 1.0f;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==1UL, "float-nuint-explicit-unchecked-wrap-4");
        }
        {
            float input = 0.75f;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "float-nuint-explicit-unchecked-wrap-6");
        }
        {
            float input = -0.75f;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "float-nuint-explicit-unchecked-wrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
