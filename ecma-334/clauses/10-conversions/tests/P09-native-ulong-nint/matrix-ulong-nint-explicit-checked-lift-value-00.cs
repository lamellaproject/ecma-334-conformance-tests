/*
Rules: P09-native-ulong-nint; P09-native-nullable-lift
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
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
            ulong? input = 0UL;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "ulong-nint-explicit-checked-lift-0");
        }
        {
            ulong? input = 1UL;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==1L, "ulong-nint-explicit-checked-lift-2");
        }
        {
            ulong? input = 9223372036854775806UL;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==9223372036854775806L, "ulong-nint-explicit-checked-lift-3");
        }
        {
            ulong? input = 9223372036854775807UL;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==9223372036854775807L, "ulong-nint-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
