/*
Rules: P09-native-ulong-nuint; P09-native-nullable-unwrap
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
            ulong? input = 0UL;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "ulong-nuint-explicit-unchecked-unwrap-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "ulong-nuint-explicit-unchecked-unwrap-1");
        }
        {
            ulong? input = 1UL;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==1UL, "ulong-nuint-explicit-unchecked-unwrap-2");
        }
        {
            ulong? input = 18446744073709551614UL;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551614UL, "ulong-nuint-explicit-unchecked-unwrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
