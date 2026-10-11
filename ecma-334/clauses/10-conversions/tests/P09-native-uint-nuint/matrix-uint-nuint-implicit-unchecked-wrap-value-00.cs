/*
Rules: P09-native-uint-nuint; P09-native-nullable-wrap
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
            uint input = 0U;
            nuint? result = unchecked(input);
            Check(result.HasValue && (ulong)result.Value==0UL, "uint-nuint-implicit-unchecked-wrap-0");
        }
        {
            uint input = 4294967295U;
            nuint? result = unchecked(input);
            Check(result.HasValue && (ulong)result.Value==4294967295UL, "uint-nuint-implicit-unchecked-wrap-1");
        }
        {
            uint input = 1U;
            nuint? result = unchecked(input);
            Check(result.HasValue && (ulong)result.Value==1UL, "uint-nuint-implicit-unchecked-wrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
