/*
Rules: P09-native-nuint-byte; P09-native-nullable-wrap
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
            nuint input = (nuint)(0UL);
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nuint-byte-explicit-checked-wrap-0");
        }
        {
            nuint input = (nuint)(1UL);
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(1), "nuint-byte-explicit-checked-wrap-2");
        }
        {
            nuint input = (nuint)(254UL);
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(254), "nuint-byte-explicit-checked-wrap-3");
        }
        {
            nuint input = (nuint)(255UL);
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nuint-byte-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
