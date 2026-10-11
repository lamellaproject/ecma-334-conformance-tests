/*
Rules: P09-native-int-nuint
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
            const int input = -2147483648;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744071562067968UL, "int-nuint-explicit-unchecked-True-0");
        }
        {
            const int input = 2147483647;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==2147483647UL, "int-nuint-explicit-unchecked-True-1");
        }
        {
            const int input = 0;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "int-nuint-explicit-unchecked-True-2");
        }
        {
            const int input = 1;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==1UL, "int-nuint-explicit-unchecked-True-3");
        }
        {
            const int input = -1;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "int-nuint-explicit-unchecked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
