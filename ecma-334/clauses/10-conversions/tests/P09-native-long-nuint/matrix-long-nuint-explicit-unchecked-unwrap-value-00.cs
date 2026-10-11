/*
Rules: P09-native-long-nuint; P09-native-nullable-unwrap
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
            long? input = long.MinValue;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==9223372036854775808UL, "long-nuint-explicit-unchecked-unwrap-0");
        }
        {
            long? input = 9223372036854775807L;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==9223372036854775807UL, "long-nuint-explicit-unchecked-unwrap-1");
        }
        {
            long? input = 0L;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "long-nuint-explicit-unchecked-unwrap-2");
        }
        {
            long? input = 1L;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==1UL, "long-nuint-explicit-unchecked-unwrap-3");
        }
        {
            long? input = -1L;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "long-nuint-explicit-unchecked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
