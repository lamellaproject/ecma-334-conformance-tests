/*
Rules: P09-native-nint-decimal; P09-native-nullable-lift
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
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
            nint? input = null;
            decimal? result = checked((decimal?)input);
            Check(!result.HasValue, "nint-decimal-explicit-checked-null-lift");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
