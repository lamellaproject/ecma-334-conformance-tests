/*
Rules: P09-native-nint-nuint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
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
            const nint input = (nint)(0L);
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "nint-nuint-explicit-checked-True-2");
        }
        {
            const nint input = (nint)(1L);
            nuint result = checked((nuint)input);
            Check((ulong)result==1UL, "nint-nuint-explicit-checked-True-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
