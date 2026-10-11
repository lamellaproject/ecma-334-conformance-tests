/*
Rules: P09-native-nuint-nint; P09-native-nullable-unwrap
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
            nuint? input = (nuint)(0UL);
            nint result = unchecked((nint)input);
            Check((long)result==0L, "nuint-nint-explicit-unchecked-unwrap-0");
        }
        {
            nuint? input = (nuint)(18446744073709551615UL);
            nint result = unchecked((nint)input);
            Check((long)result==-1L, "nuint-nint-explicit-unchecked-unwrap-1");
        }
        {
            nuint? input = (nuint)(1UL);
            nint result = unchecked((nint)input);
            Check((long)result==1L, "nuint-nint-explicit-unchecked-unwrap-2");
        }
        {
            nuint? input = (nuint)(9223372036854775806UL);
            nint result = unchecked((nint)input);
            Check((long)result==9223372036854775806L, "nuint-nint-explicit-unchecked-unwrap-3");
        }
        {
            nuint? input = (nuint)(9223372036854775807UL);
            nint result = unchecked((nint)input);
            Check((long)result==9223372036854775807L, "nuint-nint-explicit-unchecked-unwrap-4");
        }
        {
            nuint? input = (nuint)(9223372036854775808UL);
            nint result = unchecked((nint)input);
            Check((long)result==long.MinValue, "nuint-nint-explicit-unchecked-unwrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
