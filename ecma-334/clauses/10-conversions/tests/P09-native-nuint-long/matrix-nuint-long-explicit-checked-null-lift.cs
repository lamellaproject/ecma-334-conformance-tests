/*
Rules: P09-native-nuint-long; P09-native-nullable-lift
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
            nuint? input = null;
            long? result = checked((long?)input);
            Check(!result.HasValue, "nuint-long-explicit-checked-null-lift");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
