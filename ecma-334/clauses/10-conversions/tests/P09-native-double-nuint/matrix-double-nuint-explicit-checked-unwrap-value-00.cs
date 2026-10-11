/*
Rules: P09-native-double-nuint; P09-native-nullable-unwrap
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
            double? input = 0.0d;
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "double-nuint-explicit-checked-unwrap-2");
        }
        {
            double? input = -0.0d;
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "double-nuint-explicit-checked-unwrap-3");
        }
        {
            double? input = 1.0d;
            nuint result = checked((nuint)input);
            Check((ulong)result==1UL, "double-nuint-explicit-checked-unwrap-4");
        }
        {
            double? input = 0.75d;
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "double-nuint-explicit-checked-unwrap-6");
        }
        {
            double? input = -0.75d;
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "double-nuint-explicit-checked-unwrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
