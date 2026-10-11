/*
Rules: P09-native-ulong-nint
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
            const ulong input = 0UL;
            nint result = checked((nint)input);
            Check((long)result==0L, "ulong-nint-explicit-checked-True-0");
        }
        {
            const ulong input = 1UL;
            nint result = checked((nint)input);
            Check((long)result==1L, "ulong-nint-explicit-checked-True-2");
        }
        {
            const ulong input = 9223372036854775806UL;
            nint result = checked((nint)input);
            Check((long)result==9223372036854775806L, "ulong-nint-explicit-checked-True-3");
        }
        {
            const ulong input = 9223372036854775807UL;
            nint result = checked((nint)input);
            Check((long)result==9223372036854775807L, "ulong-nint-explicit-checked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
