/*
Rules: P09-native-nuint-ushort; P09-native-nullable-wrap
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
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nuint-ushort-explicit-checked-wrap-0");
        }
        {
            nuint input = (nuint)(1UL);
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(1), "nuint-ushort-explicit-checked-wrap-2");
        }
        {
            nuint input = (nuint)(65534UL);
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65534), "nuint-ushort-explicit-checked-wrap-3");
        }
        {
            nuint input = (nuint)(65535UL);
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nuint-ushort-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
