/*
Rules: P09-native-ulong-nuint
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
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "ulong-nuint-explicit-checked-True-0");
        }
        {
            const ulong input = 18446744073709551615UL;
            nuint result = checked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "ulong-nuint-explicit-checked-True-1");
        }
        {
            const ulong input = 1UL;
            nuint result = checked((nuint)input);
            Check((ulong)result==1UL, "ulong-nuint-explicit-checked-True-2");
        }
        {
            const ulong input = 18446744073709551614UL;
            nuint result = checked((nuint)input);
            Check((ulong)result==18446744073709551614UL, "ulong-nuint-explicit-checked-True-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
