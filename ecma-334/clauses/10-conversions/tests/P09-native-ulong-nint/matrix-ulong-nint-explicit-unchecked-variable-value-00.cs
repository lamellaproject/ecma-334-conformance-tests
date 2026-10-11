/*
Rules: P09-native-ulong-nint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 6
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
            ulong input = 0UL;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "ulong-nint-explicit-unchecked-False-0");
        }
        {
            ulong input = 18446744073709551615UL;
            nint result = unchecked((nint)input);
            Check((long)result==-1L, "ulong-nint-explicit-unchecked-False-1");
        }
        {
            ulong input = 1UL;
            nint result = unchecked((nint)input);
            Check((long)result==1L, "ulong-nint-explicit-unchecked-False-2");
        }
        {
            ulong input = 9223372036854775806UL;
            nint result = unchecked((nint)input);
            Check((long)result==9223372036854775806L, "ulong-nint-explicit-unchecked-False-3");
        }
        {
            ulong input = 9223372036854775807UL;
            nint result = unchecked((nint)input);
            Check((long)result==9223372036854775807L, "ulong-nint-explicit-unchecked-False-4");
        }
        {
            ulong input = 9223372036854775808UL;
            nint result = unchecked((nint)input);
            Check((long)result==long.MinValue, "ulong-nint-explicit-unchecked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
