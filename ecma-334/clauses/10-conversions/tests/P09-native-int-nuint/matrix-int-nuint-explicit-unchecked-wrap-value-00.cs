/*
Rules: P09-native-int-nuint; P09-native-nullable-wrap
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
            int input = -2147483648;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==18446744071562067968UL, "int-nuint-explicit-unchecked-wrap-0");
        }
        {
            int input = 2147483647;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==2147483647UL, "int-nuint-explicit-unchecked-wrap-1");
        }
        {
            int input = 0;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "int-nuint-explicit-unchecked-wrap-2");
        }
        {
            int input = 1;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==1UL, "int-nuint-explicit-unchecked-wrap-3");
        }
        {
            int input = -1;
            nuint? result = unchecked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==18446744073709551615UL, "int-nuint-explicit-unchecked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
