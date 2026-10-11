/*
Rules: P09-native-nuint-nint
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
            const nuint input = (nuint)(0UL);
            nint result = checked((nint)input);
            Check((long)result==0L, "nuint-nint-explicit-checked-True-0");
        }
        {
            const nuint input = (nuint)(1UL);
            nint result = checked((nint)input);
            Check((long)result==1L, "nuint-nint-explicit-checked-True-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
