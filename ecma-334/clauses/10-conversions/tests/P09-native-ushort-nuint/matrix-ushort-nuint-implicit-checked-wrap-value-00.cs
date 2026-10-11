/*
Rules: P09-native-ushort-nuint; P09-native-nullable-wrap
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
            ushort input = (ushort)(0);
            nuint? result = checked(input);
            Check(result.HasValue && (ulong)result.Value==0UL, "ushort-nuint-implicit-checked-wrap-0");
        }
        {
            ushort input = (ushort)(65535);
            nuint? result = checked(input);
            Check(result.HasValue && (ulong)result.Value==65535UL, "ushort-nuint-implicit-checked-wrap-1");
        }
        {
            ushort input = (ushort)(1);
            nuint? result = checked(input);
            Check(result.HasValue && (ulong)result.Value==1UL, "ushort-nuint-implicit-checked-wrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
