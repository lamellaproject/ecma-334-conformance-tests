/*
Rules: P09-native-nint-nuint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
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
            nint input = (nint)(long.MinValue);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==9223372036854775808UL, "nint-nuint-explicit-unchecked-False-0");
        }
        {
            nint input = (nint)(9223372036854775807L);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==9223372036854775807UL, "nint-nuint-explicit-unchecked-False-1");
        }
        {
            nint input = (nint)(0L);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "nint-nuint-explicit-unchecked-False-2");
        }
        {
            nint input = (nint)(1L);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==1UL, "nint-nuint-explicit-unchecked-False-3");
        }
        {
            nint input = (nint)(-1L);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "nint-nuint-explicit-unchecked-False-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
