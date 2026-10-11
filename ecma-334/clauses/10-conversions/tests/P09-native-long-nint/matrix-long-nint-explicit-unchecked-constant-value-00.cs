/*
Rules: P09-native-long-nint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
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
            const long input = long.MinValue;
            nint result = unchecked((nint)input);
            Check((long)result==long.MinValue, "long-nint-explicit-unchecked-True-0");
        }
        {
            const long input = 9223372036854775807L;
            nint result = unchecked((nint)input);
            Check((long)result==9223372036854775807L, "long-nint-explicit-unchecked-True-1");
        }
        {
            const long input = 0L;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "long-nint-explicit-unchecked-True-2");
        }
        {
            const long input = 1L;
            nint result = unchecked((nint)input);
            Check((long)result==1L, "long-nint-explicit-unchecked-True-3");
        }
        {
            const long input = -1L;
            nint result = unchecked((nint)input);
            Check((long)result==-1L, "long-nint-explicit-unchecked-True-4");
        }
        {
            const long input = -9223372036854775807L;
            nint result = unchecked((nint)input);
            Check((long)result==-9223372036854775807L, "long-nint-explicit-unchecked-True-5");
        }
        {
            const long input = 9223372036854775806L;
            nint result = unchecked((nint)input);
            Check((long)result==9223372036854775806L, "long-nint-explicit-unchecked-True-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
