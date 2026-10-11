/*
Rules: P09-native-decimal-nuint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
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
            const decimal input = -0.1m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-True-6");
        }
        {
            const decimal input = -1E-28m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-True-8");
        }
        {
            const decimal input = -0.75m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-True-12");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
