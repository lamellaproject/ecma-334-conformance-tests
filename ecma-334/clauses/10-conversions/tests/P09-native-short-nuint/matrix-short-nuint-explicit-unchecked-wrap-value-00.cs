/*
Rules: P09-native-short-nuint; P09-native-nullable-wrap
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
            short input = (short)(-32768);
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==18446744073709518848UL, "short-nuint-explicit-unchecked-wrap-0");
        }
        {
            short input = (short)(32767);
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==32767UL, "short-nuint-explicit-unchecked-wrap-1");
        }
        {
            short input = (short)(0);
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "short-nuint-explicit-unchecked-wrap-2");
        }
        {
            short input = (short)(1);
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==1UL, "short-nuint-explicit-unchecked-wrap-3");
        }
        {
            short input = (short)(-1);
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==18446744073709551615UL, "short-nuint-explicit-unchecked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
