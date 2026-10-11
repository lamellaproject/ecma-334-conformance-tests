/*
Rules: P09-native-int-nuint; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
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
            int input = 2147483647;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==2147483647UL, "int-nuint-explicit-checked-wrap-1");
        }
        {
            int input = 0;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "int-nuint-explicit-checked-wrap-2");
        }
        {
            int input = 1;
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==1UL, "int-nuint-explicit-checked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
