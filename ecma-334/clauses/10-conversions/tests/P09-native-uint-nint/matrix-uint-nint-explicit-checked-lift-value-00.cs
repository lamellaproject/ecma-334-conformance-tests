/*
Rules: P09-native-uint-nint; P09-native-nullable-lift
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
            uint? input = 0U;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "uint-nint-explicit-checked-lift-0");
        }
        {
            uint? input = 4294967295U;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==4294967295L, "uint-nint-explicit-checked-lift-1");
        }
        {
            uint? input = 1U;
            nint? result = checked((nint?)input);
            Check(result.HasValue && (long)result.Value==1L, "uint-nint-explicit-checked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
