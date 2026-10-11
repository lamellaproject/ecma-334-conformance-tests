/*
Rules: P09-native-nint-ulong; P09-native-nullable-wrap
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
            nint input = (nint)(9223372036854775807L);
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==9223372036854775807UL, "nint-ulong-explicit-checked-wrap-1");
        }
        {
            nint input = (nint)(0L);
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nint-ulong-explicit-checked-wrap-2");
        }
        {
            nint input = (nint)(1L);
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==1UL, "nint-ulong-explicit-checked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
