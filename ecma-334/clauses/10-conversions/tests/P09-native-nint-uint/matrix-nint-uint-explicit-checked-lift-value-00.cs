/*
Rules: P09-native-nint-uint; P09-native-nullable-lift
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
            nint? input = (nint)(0L);
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nint-uint-explicit-checked-lift-2");
        }
        {
            nint? input = (nint)(1L);
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==1U, "nint-uint-explicit-checked-lift-3");
        }
        {
            nint? input = (nint)(4294967294L);
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==4294967294U, "nint-uint-explicit-checked-lift-5");
        }
        {
            nint? input = (nint)(4294967295L);
            uint? result = checked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nint-uint-explicit-checked-lift-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
